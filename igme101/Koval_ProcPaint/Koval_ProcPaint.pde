//Claire Koval
//30 Sept. 2016
//Proc.Paint

boolean isClicked;
int boxX=40;
int boxDimensions=40;
color c; //will hold color variable that changes as buttons pressed
int d=1; //used when saving
float circleWidth=1;
float circleHeight=1;
int rectCorner=8;

void setup()
{
  size(1000, 640);
  background(255);
}
void draw()
{
  noStroke();
  fill(#5A5A5A); //background box
  rect(0, 0, 120, 480, 8);
  //box colors from lightest to darkest
  fill(#4DFF9E);
  rect(boxX, 40, boxDimensions, boxDimensions, rectCorner); //top
  fill(#46E08C);
  rect(boxX, 80, boxDimensions, boxDimensions, rectCorner);
  fill(#35C175);
  rect(boxX, 120, boxDimensions, boxDimensions, rectCorner);
  fill(#24A760);
  rect(boxX, 160, boxDimensions, boxDimensions, rectCorner);
  fill(#0F8B48);
  rect(boxX, 200, boxDimensions, boxDimensions, rectCorner);
  fill(#066F36);
  rect(boxX, 240, boxDimensions, boxDimensions, rectCorner);
  fill(#015527);
  rect(boxX, 280, boxDimensions, boxDimensions, rectCorner);
  fill(#02361A);
  rect(boxX, 320, boxDimensions, boxDimensions, rectCorner); //bottom
  fill(255);
  rect(boxX, 360, boxDimensions, boxDimensions, rectCorner); //eraser
  rect(boxX, 400, boxDimensions, boxDimensions, rectCorner); //random
  fill(0); //"eraser" to label box
  text("eraser", 44, 384);
  text("random", 40, 424);
}


void mouseClicked() //set perameters for mouse clicked (buttons), top to bottom buttons
{
  if ((mouseX>0)&&(mouseX<1000)&&(mouseY>0) &&(mouseY<640)) {
    c=0;
    isClicked=true; //start-up
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>40) &&(mouseY<80 )) {
    c=#4DFF9E;
    isClicked=true; //#4DFF9E
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>80) &&(mouseY<120)) {
    c=#46E08C;
    isClicked=true; //#46E08C
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>120 ) &&(mouseY<160)) {
    c=#35C175;
    isClicked=true;//#35C175
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>160 ) &&(mouseY<200)) {
    c=#24A760;
    isClicked=true; //#24A760
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>200) &&(mouseY<240)) {
    c=#0F8B48;
    isClicked=true; //#0F8B48
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>240) &&(mouseY<280)) {
    c=#066F36;
    isClicked=true;//#066F36
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>280) &&(mouseY<320)) {
    c=#015527;
    isClicked=true; //#015527
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>320) &&(mouseY<360)) {
    c=#02361A;
    isClicked=true; //#02361A
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>360) &&(mouseY<400)) {
    c=255;
    isClicked=true;//eraser
  }
  if ((mouseX>boxX)&&(mouseX<80)&&(mouseY>400) &&(mouseY<440)) {
    randomPattern();
    isClicked=true;//random
  }
}

void mouseDragged()
{ //draw and change color if mouse clicked in perameters to change to true
  if ((isClicked == true)) {
    strokeCap(ROUND);
    stroke(c);
    line(mouseX, mouseY, pmouseX, pmouseY); //line from mouse coordinates
  }
}

void keyPressed()
{
  if (key=='c') { //clear background to white
    background(255);
  }
  if (key == '1') {
    strokeWeight(1); //changing stroke weight
  }
  if (key == '2') {
    strokeWeight(2);
  }
  if (key == '3') {
    strokeWeight(3);
  }
  if (key == '4') {
    strokeWeight(4);
  }
  if (key == '5') {
    strokeWeight(5);
  }
  if (key == '6') {
    strokeWeight(6);
  }
  if (key == '7') {
    strokeWeight(7);
  }
  if (key == '8') {
    strokeWeight(8);
  }
  if (key == '9') {
    strokeWeight(9);
  }
  if (key == 's') //save button
  {
    save("screen" + d + ".png" ); //name, number as multiple images can be saved
    d= d + 1;
  }
  if (key == 'b')
  {
    c=0;
    isClicked=true;
  }
  if (key == CODED) {
    background(255); //clear past circles
    ellipse(width/2, height/2, circleWidth, circleHeight); //center circle
    if (keyCode == UP) { //growing circle
      circleWidth=circleWidth+16;
      circleHeight=circleHeight+16;
    } else if (keyCode == DOWN) { //shrinking circle
      circleWidth=circleWidth-16;
      circleHeight=circleHeight-16;
    }
  }
}

void randomPattern() { //black checked background with white squares, intentionally bare bottom left corner
  background(0);
  for (int n=0; n<8; n++) {
    stroke(255);
    fill(255);
    rect(n*80, n*80, 80, 80);
    rect((n+2)*80, n*80, 80, 80);
    rect((n+4)*80, n*80, 80, 80);
    rect((n+6)*80, n*80, 80, 80);
    rect((n+8)*80, n*80, 80, 80);
    rect((n+10)*80, n*80, 80, 80);
    rect((n+12)*80, n*80, 80, 80);
  }
}