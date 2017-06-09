using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using Leap;

namespace PerfectArm {
    public partial class FrmPrincipale : Form {
        private Controller _controller;
        private LeapEventListener _listener;

        public FrmPrincipale() { InitializeComponent(); }

        private void cmdCollega_Click(object sender, EventArgs e) {
            try {
                Log("");
                Log("---------------------------------------------------------");
                Log("Inizializzazione");
                _controller = new Controller();
                _listener = new LeapEventListener(this);
                _controller.AddListener(_listener);
                lblStato.Text = "Connected";
                lblStato.ForeColor = Color.Green;
                Log("Connesso Leap");

                serial.PortName = cmbSerial.Text;
                serial.Open();
                Sendhoriz(0,0);
            }
            catch (Exception ex) {
                LogError("Errore connessione", ex);
               // cmdScollega_Click(null, null);
            }
        }

        private void cmdScollega_Click(object sender, EventArgs e) {
            try {
                if (_controller != null) {
                    _controller.RemoveListener(_listener);
                    _controller.Dispose();
                }
                Log("Disconesso");
                serial.Close();
            }
            catch (Exception ex) {
                LogError("Errore Disconnessione", ex);
            } finally {
                lblStato.Text = "Not Connected";
                lblStato.ForeColor = Color.Red;
                _controller = null;
                _listener = null;
                lblFrame.Text = "";
            }
        }

        private delegate void AddLog(String text);

        private delegate void AddLogError(String text,Exception ex);

        private delegate void FrameUpdate(String text);

        private delegate void HandUpdate(String text);

        private delegate void Send(int angleHor, int angleVert);

        public void Sendhoriz(int angleHor, int angleVert)
        {
            Send f = Sendhorizint;
            Invoke(f, new object[]{angleHor,angleVert});
        }

        public void Sendhorizint(int angleHor, int angleVert) {
            angleHor = -angleHor;
            if (angleHor > 35) angleHor = 35;
            angleHor += 90;
            serial.Write(new byte[] {(byte)angleHor,(byte)angleVert },0,2);
        }


        public void Frame(string text)
        {
            FrameUpdate f = Frameint;
            Invoke(f, text);
        }

        public void Hand(string text)
        {
            HandUpdate f = Handint;
            Invoke(f, text);
        }

        private void Frameint(String text) { lblFrame.Text = text; }

        private void Handint(String text) { lblHand.Text = text; }


        public void Log(string text) {
            AddLog f = Logint;
            Invoke(f, text);
        }

        public void LogError(string text, Exception ex)
        {
            AddLogError f = LogErrorInt;
            Invoke(f, new object[] { text,ex });
        }

        private void Logint(string text) {
            lstLog.Items.Add(text);
            var visibleItems = lstLog.ClientSize.Height/lstLog.ItemHeight;
            lstLog.TopIndex = Math.Max(lstLog.Items.Count - visibleItems + 1, 0);
        }

        private void LogErrorInt(string text, Exception ex) {
            Log("ERRORE: " + text);
            while (ex != null) {
                Log("        " + ex.Message);
                ex = ex.InnerException;
            }
        }

        private void FrmPrincipale_Load(Object sender, EventArgs e)
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            // Display each port name to the console.
            foreach (string port in ports) {
                cmbSerial.Items.Add(port);
            }

     
        }

        private void cmdCambiaAngolo_Click(Object sender, EventArgs e)
        {
            serial.Write(new byte[] {byte.Parse(textBox1.Text), byte.Parse(textBox2.Text) },0,2);
        }
    }

    public class LeapEventListener : Listener {
        private readonly FrmPrincipale _principal;

        public LeapEventListener(FrmPrincipale principal) { _principal = principal; }
        public override void OnFrame(Controller controller) {
            // Get the most recent frame and report some basic information
            Frame frame = controller.Frame();

            _principal.Frame("Frame id: " + frame.Id
                        + ", timestamp: " + frame.Timestamp
                        + ", hands: " + frame.Hands.Count
                        + ", fingers: " + frame.Fingers.Count
                        + ", tools: " + frame.Tools.Count
                        + ", gestures: " + frame.Gestures().Count);

            foreach (Hand hand in frame.Hands)
            {
                // Get the hand's normal vector and direction
                Vector normal = hand.PalmNormal;
                Vector direction = hand.Direction;

                // Calculate the hand's pitch, roll, and yaw angles
                String t =( "Hand id: " + hand.Id
                            + "\npalm position: " + hand.PalmPosition
                            + "\npitch (degrees): " + direction.Pitch * 180.0f / (float)Math.PI + "  "
                            + "\nroll (degrees): " + normal.Roll * 180.0f / (float)Math.PI
                            + "\nyaw (degrees): " + direction.Yaw * 180.0f / (float)Math.PI);

                int rotoriz = (int) (direction.Yaw*180.0f/(float) Math.PI);
                int rotVert = (int)(direction.Pitch * 180.0f / (float)Math.PI); ;
                _principal.Sendhoriz(rotoriz, rotVert);
                _principal.Log(t);
                _principal.Hand(t);

                /*
                // Get the Arm bone
                Arm arm = hand.Arm;
                _principal.Log("  Arm direction: " + arm.Direction
                            + ", wrist position: " + arm.WristPosition
                            + ", elbow position: " + arm.ElbowPosition);
                
                // Get fingers
                foreach (Finger finger in hand.Fingers)
                {
                    _principal.Log("    Finger id: " + finger.Id
                                + ", " + finger.Type.ToString()
                                + ", length: " + finger.Length
                                + "mm, width: " + finger.Width + "mm");

                    // Get finger bones
                    Bone bone;
                    foreach (Bone.BoneType boneType in (Bone.BoneType[])Enum.GetValues(typeof(Bone.BoneType)))
                    {
                        bone = finger.Bone(boneType);
                        _principal.Log("      Bone: " + boneType
                                    + ", start: " + bone.PrevJoint
                                    + ", end: " + bone.NextJoint
                                    + ", direction: " + bone.Direction);
                    }
                }
                */
            }

            // Get tools
            foreach (Tool tool in frame.Tools)
            {
                _principal.Log("  Tool id: " + tool.Id
                            + ", position: " + tool.TipPosition
                            + ", direction " + tool.Direction);
            }

            if (!frame.Hands.IsEmpty || !frame.Gestures().IsEmpty)
            {
                _principal.Log("");
            }
        }

        public override void OnInit(Controller controller) { _principal.Log("Initialized"); }

        public override void OnConnect(Controller controller) {
            _principal.Log("Connected");
            //If using gestures, enable them:
            //controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        //Not dispatched when running in debugger
        public override void OnDisconnect(Controller controller) { _principal.Log(" Listener Disconnected"); }

        private void GestureGest(Controller controller,Frame frame) {

            // Get gestures
            GestureList gestures = frame.Gestures();
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[i];

                switch (gesture.Type)
                {
                    case Gesture.GestureType.TYPE_CIRCLE:
                        CircleGesture circle = new CircleGesture(gesture);

                        // Calculate clock direction using the angle between circle normal and pointable
                        String clockwiseness;
                        if (circle.Pointable.Direction.AngleTo(circle.Normal) <= Math.PI / 2)
                        {
                            //Clockwise if angle is less than 90 degrees
                            clockwiseness = "clockwise";
                        }
                        else
                        {
                            clockwiseness = "counterclockwise";
                        }

                        float sweptAngle = 0;

                        // Calculate angle swept since last frame
                        if (circle.State != Gesture.GestureState.STATE_START)
                        {
                            CircleGesture previousUpdate = new CircleGesture(controller.Frame(1).Gesture(circle.Id));
                            sweptAngle = (circle.Progress - previousUpdate.Progress) * 360;
                        }

                        _principal.Log("  Circle id: " + circle.Id
                                       + ", " + circle.State
                                       + ", progress: " + circle.Progress
                                       + ", radius: " + circle.Radius
                                       + ", angle: " + sweptAngle
                                       + ", " + clockwiseness);
                        break;
                    case Gesture.GestureType.TYPE_SWIPE:
                        SwipeGesture swipe = new SwipeGesture(gesture);
                        _principal.Log("  Swipe id: " + swipe.Id
                                       + ", " + swipe.State
                                       + ", position: " + swipe.Position
                                       + ", direction: " + swipe.Direction
                                       + ", speed: " + swipe.Speed);
                        break;
                    case Gesture.GestureType.TYPE_KEY_TAP:
                        KeyTapGesture keytap = new KeyTapGesture(gesture);
                        _principal.Log("  Tap id: " + keytap.Id
                                       + ", " + keytap.State
                                       + ", position: " + keytap.Position
                                       + ", direction: " + keytap.Direction);
                        break;
                    case Gesture.GestureType.TYPE_SCREEN_TAP:
                        ScreenTapGesture screentap = new ScreenTapGesture(gesture);
                        _principal.Log("  Tap id: " + screentap.Id
                                       + ", " + screentap.State
                                       + ", position: " + screentap.Position
                                       + ", direction: " + screentap.Direction);
                        break;
                    default:
                        _principal.Log("  Unknown gesture type.");
                        break;
                }
            }

        }
    }
}