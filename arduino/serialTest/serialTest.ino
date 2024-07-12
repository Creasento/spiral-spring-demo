int m1 = 5;
unsigned long previousMillis = 0;
const long interval1 = 1000;
const long interval2 = 200;

void setup() {
  pinMode(m1, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  if (Serial.available()) {
    char serialData = Serial.read();
    Serial.print(serialData);

    if (serialData == '1') {
      motorOn(interval1);
    }
    else if (serialData == '2') {
      motorOn(interval2);
    }
  }
}

void motorOn(long interval) {
  unsigned long currentMillis = millis();

  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;
    digitalWrite(m1, HIGH);
    delay(1000); // LED 켜기 시간
    digitalWrite(m1, LOW);
  }
}
