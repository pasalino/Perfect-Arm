

#include <Servo.h>


Servo myservo;  // create servo object to control a servo
Servo myservo2;  // create servo object to control a servo

// twelve servo objects can be created on most boards

int pos = 0;    // variable to store the servo position
int pos2 = 0;    // variable to store the servo position


void setup() {
  Serial.begin(9600);
  myservo.attach(7);  // attaches the servo on pin 9 to the servo object
  myservo2.attach(8);  // attaches the servo on pin 9 to the servo object
}

void loop() {
  char ss[2];
  if (Serial.available() >=2) {
      Serial.readBytes(ss,2);
      myservo2.write(ss[0]);
      myservo.write(ss[1]);     
  }

  
}

