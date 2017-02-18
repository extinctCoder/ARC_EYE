int motor_A_1 = 3;
int motor_A_2 = 4;
int motor_B_1 = 5;
int motor_B_2 = 6;
int motor_C_1 = 7;
int motor_C_2 = 8;
int motor_D_1 = 9;
int motor_D_2 = 10;
void setup() {
  Serial.begin(9600);
  pinMode(motor_A_1,OUTPUT);
  pinMode(motor_A_2,OUTPUT);
  pinMode(motor_B_1,OUTPUT);
  pinMode(motor_B_2,OUTPUT);
  pinMode(motor_C_1,OUTPUT);
  pinMode(motor_C_2,OUTPUT);
  pinMode(motor_D_1,OUTPUT);
  pinMode(motor_D_2,OUTPUT);
  Serial.println("ARDUINO : Rover is ready to movement");
}
void loop() {
  if(Serial.available()>0)
  {
    int input = Serial.read();
    Serial.print("ARDUINO : recived Command : ");
    Serial.println((char)input);
    switch(input)
    {
     case 'w' : forwardDerection();
     break;
     case 's' : reverseDerection();
     break;
     case 'a' : leftDerection();
     break;
     case 'd' : rightDerection();
     break;
     case 'q' : forntLeftDerection();
     break;
     case 'e' : frontRightDerection();
     break;
     case 'z' : BackLeftDerection();
     break;
     case 'c' : BackRightDerection();
     break;
     case 'x' : stopMotor();
     break;
     default : worngCommand();
     break;
    }
  } 
  delay(50);
}
void forwardDerection(){
  digitalWrite(motor_A_1,HIGH);
  digitalWrite(motor_A_2,LOW);
  digitalWrite(motor_B_1,HIGH);
  digitalWrite(motor_B_2,LOW);
  digitalWrite(motor_C_1,HIGH);
  digitalWrite(motor_C_2,LOW);
  digitalWrite(motor_D_1,HIGH);
  digitalWrite(motor_D_2,LOW);
  delay(1000);
  Serial.println("ARDUINO : forwardDerection");
  }
void reverseDerection(){
  digitalWrite(motor_A_1,LOW);
  digitalWrite(motor_A_2,HIGH);
  digitalWrite(motor_B_1,LOW);
  digitalWrite(motor_B_2,HIGH);
  digitalWrite(motor_C_1,LOW);
  digitalWrite(motor_C_2,HIGH);
  digitalWrite(motor_D_1,LOW);
  digitalWrite(motor_D_2,HIGH);
  delay(1000);
  Serial.println("ARDUINO : reverseDerection");
  }
void rightDerection(){
  digitalWrite(motor_A_1,HIGH);
  digitalWrite(motor_A_2,LOW);
  digitalWrite(motor_B_1,LOW);
  digitalWrite(motor_B_2,HIGH);
  digitalWrite(motor_C_1,HIGH);
  digitalWrite(motor_C_2,LOW);
  digitalWrite(motor_D_1,LOW);
  digitalWrite(motor_D_2,HIGH);
  delay(1000);
  Serial.println("ARDUINO : rightDerection");
  }
void leftDerection(){
  digitalWrite(motor_A_1,LOW);
  digitalWrite(motor_A_2,HIGH);
  digitalWrite(motor_B_1,HIGH);
  digitalWrite(motor_B_2,LOW);
  digitalWrite(motor_C_1,LOW);
  digitalWrite(motor_C_2,HIGH);
  digitalWrite(motor_D_1,HIGH);
  digitalWrite(motor_D_2,LOW);
  delay(1000);
  Serial.println("ARDUINO : leftDerection");
  }
void frontRightDerection(){
  digitalWrite(motor_A_1,LOW);
  digitalWrite(motor_A_2,HIGH);
  digitalWrite(motor_B_1,LOW);
  digitalWrite(motor_B_2,HIGH);
  digitalWrite(motor_C_1,LOW);
  digitalWrite(motor_C_2,HIGH);
  digitalWrite(motor_D_1,LOW);
  digitalWrite(motor_D_2,HIGH);
  delay(1000);
  Serial.println("ARDUINO : frontRightDerection");
  }
void forntLeftDerection(){
  digitalWrite(motor_A_1,HIGH);
  digitalWrite(motor_A_2,LOW);
  digitalWrite(motor_B_1,LOW);
  digitalWrite(motor_B_2,HIGH);
  digitalWrite(motor_C_1,HIGH);
  digitalWrite(motor_C_2,LOW);
  digitalWrite(motor_D_1,LOW);
  digitalWrite(motor_D_2,HIGH);
  delay(1000);
  Serial.println("ARDUINO : frontLeftDerection");
  }
void BackRightDerection(){
  digitalWrite(motor_A_1,HIGH);
  digitalWrite(motor_A_2,LOW);
  digitalWrite(motor_B_1,LOW);
  digitalWrite(motor_B_2,HIGH);
  digitalWrite(motor_C_1,HIGH);
  digitalWrite(motor_C_2,LOW);
  digitalWrite(motor_D_1,LOW);
  digitalWrite(motor_D_2,HIGH);
  delay(1000);
  Serial.println("ARDUINO : backRightDerection");
  }
void BackLeftDerection(){
  digitalWrite(motor_A_1,LOW);
  digitalWrite(motor_A_2,HIGH);
  digitalWrite(motor_B_1,LOW);
  digitalWrite(motor_B_2,HIGH);
  digitalWrite(motor_C_1,LOW);
  digitalWrite(motor_C_2,HIGH);
  digitalWrite(motor_D_1,LOW);
  digitalWrite(motor_D_2,HIGH);
  delay(1000);
  Serial.println("ARDUINO : backLeftDerection");
  }
void stopMotor(){
  digitalWrite(motor_A_1,LOW);
  digitalWrite(motor_A_2,LOW);
  digitalWrite(motor_B_1,LOW);
  digitalWrite(motor_B_2,LOW);
  digitalWrite(motor_C_1,LOW);
  digitalWrite(motor_C_2,LOW);
  digitalWrite(motor_D_1,LOW);
  digitalWrite(motor_D_2,LOW);
  delay(1000);
  Serial.println("ARDUINO : stopMotor");
  }
void worngCommand(){
  delay(1000);
  Serial.println("ARDUINO : wrong coomand recived");
  }
