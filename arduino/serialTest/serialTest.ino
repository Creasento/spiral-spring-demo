int m1 = 5;
int dir1Pin_A = 16;
int dir2Pin_A = 14;

int normalDelay = 1000;
int doubleDelay = normalDelay * 2;
int tripleDelay = normalDelay * 3-500;

int currentMotorState = 0;

unsigned long balloonTimeGo;
unsigned long balloonTimeBack;

void setup() {
  pinMode(dir1Pin_A, OUTPUT);
  pinMode(dir2Pin_A, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  if (Serial.available()) {
    char serialData = Serial.read();
    Serial.print(serialData);

    if (serialData == '1' && currentMotorState == 0) {
      motorGo(normalDelay);
      currentMotorState  = 1;
    }
    else if (serialData == '1' && currentMotorState == 2) {
      motorBack(normalDelay);
      currentMotorState = 1;
    }
    else if (serialData == '1' && currentMotorState == 3) {
      motorBack(doubleDelay);
      currentMotorState = 1;
    }


    if (serialData == '2' && currentMotorState == 0) {
      motorGo(doubleDelay);
      currentMotorState  = 2;
    }
    else if (serialData == '2' && currentMotorState == 1) {
      motorGo(normalDelay);
      currentMotorState = 2;
    }
    else if (serialData == '2' && currentMotorState == 3) {
      motorBack(normalDelay);
      currentMotorState = 2;
    }


    if (serialData == '3' && currentMotorState == 0) {
      motorGo(tripleDelay);
      currentMotorState  = 3;
    }
    else if (serialData == '3' && currentMotorState == 1) {
      motorGo(doubleDelay);
      currentMotorState = 3;
    }
    else if (serialData == '3' && currentMotorState == 2) {
      motorGo(normalDelay);
      currentMotorState = 3;
    }

    if (serialData == '0' && currentMotorState == 1) {
      motorBack(normalDelay);
      currentMotorState  = 0;
    }
    else if (serialData == '0' && currentMotorState == 2) {
      motorBack(doubleDelay);
      currentMotorState = 0;
    }
    else if (serialData == '0' && currentMotorState == 3) {
      motorBack(tripleDelay);
      currentMotorState = 0;
    }

    if (serialData == 'g') {
      motorGo(normalDelay);
    }
    else if (serialData == 'h') {
      motorBack(normalDelay);
    }
    else if (serialData == 'o') {
      currentMotorState = 0;
    }

    if (serialData == 'd') {
      motorBalloonGo();
    }
    else if (serialData == 's') {
      motorStop();
    }
    else if (serialData == 'f') {
      motorBalloonBack();
    }
    else if (serialData == 'r') {
      motorReset();
    }

  }
}

void motorGo(int delayTime) {

  digitalWrite(dir1Pin_A, HIGH);
  digitalWrite(dir2Pin_A, LOW);
  delay(delayTime); // LED 켜기 시간
  digitalWrite(dir1Pin_A, LOW);
  digitalWrite(dir2Pin_A, LOW);

}

void motorBack(int delayTime) {

  digitalWrite(dir1Pin_A, LOW);
  digitalWrite(dir2Pin_A, HIGH);
  delay(delayTime); // LED 켜기 시간
  digitalWrite(dir1Pin_A, LOW);
  digitalWrite(dir2Pin_A, LOW);

}

void motorBalloonGo() {
  unsigned long startTimeGo = millis(); // 함수 실행 시작 시간 기록

  digitalWrite(dir1Pin_A, HIGH);
  digitalWrite(dir2Pin_A, LOW);

  unsigned long endTimeGo = millis(); // 함수 실행 종료 시간 기록
  balloonTimeGo = endTimeGo - startTimeGo; // 함수 실행 시간 계산 및 저장
}

void motorBalloonBack() {
  unsigned long startTimeBack = millis(); // 함수 실행 시작 시간 기록

  digitalWrite(dir1Pin_A, LOW);
  digitalWrite(dir2Pin_A, HIGH);

  unsigned long endTimeBack = millis(); // 함수 실행 종료 시간 기록
  balloonTimeBack = endTimeBack - startTimeBack; // 함수 실행 시간 계산 및 저장
}

void motorReset() {
  unsigned long resetTime = balloonTimeGo - balloonTimeBack;
  if (resetTime >= 0) {
    digitalWrite(dir1Pin_A, LOW);
    digitalWrite(dir2Pin_A, HIGH);
    delay(resetTime);
    digitalWrite(dir1Pin_A, LOW);
    digitalWrite(dir2Pin_A, LOW);
  }
  else {
    digitalWrite(dir1Pin_A, HIGH);
    digitalWrite(dir2Pin_A, LOW);
    delay(resetTime);
    digitalWrite(dir1Pin_A, LOW);
    digitalWrite(dir2Pin_A, LOW);
  }
}

void motorStop() {
  digitalWrite(dir1Pin_A, LOW);
  digitalWrite(dir2Pin_A, LOW);

}
