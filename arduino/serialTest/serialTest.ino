int m1 = 5;
unsigned long previousMillis = 0;
const long interval1 = 1000; // 1초 간격
const long interval2 = 200;  // 200ms 간격

void setup() {
  pinMode(m1, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  if (Serial.available()) {
    char serialData = Serial.read(); // 개별 문자 읽기
    Serial.print(serialData);

    if (serialData == '1') {
      blinkLED(interval1); // 1초 간격으로 LED 깜빡이기
    }
    else if (serialData == '2') {
      blinkLED(interval2); // 200ms 간격으로 LED 깜빡이기
    }
  }
}

void blinkLED(long interval) {
  unsigned long currentMillis = millis();

  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;
    digitalWrite(m1, HIGH);
    delay(1000); // LED 켜기 시간
    digitalWrite(m1, LOW);
  }
}
