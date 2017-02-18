int incomingByte = 0;
int ledPin = 13;
 
void setup(){
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
}
 
void loop(){
  if (true) {
    // read the incoming byte:
    incomingByte = Serial.read();
 
    // say what you got:
    if(incomingByte == 49) { // ASCII printable characters: 49 means number 1
    digitalWrite(ledPin, HIGH);
    delay(1000);
    }
  else if(incomingByte == 48) { // ASCII printable characters: 48 means number 0
    digitalWrite(ledPin, LOW);
    delay(1000);
    }
  }
}
