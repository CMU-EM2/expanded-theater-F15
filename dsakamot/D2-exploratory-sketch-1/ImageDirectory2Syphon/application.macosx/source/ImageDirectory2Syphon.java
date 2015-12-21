import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import processing.opengl.*; 
import codeanticode.syphon.*; 
import ddf.minim.*; 

import codeanticode.syphon.*; 
import jsyphon.util.*; 
import jsyphon.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class ImageDirectory2Syphon extends PApplet {






SyphonServer server;

String syphonServerName = "Latest Image in Directory Syphon";
PImage img;

public void setup() {
  size(10, 10, P3D);
  server = new SyphonServer(this, syphonServerName);
}

public void draw() {
  String path = "/Users/dsakamot/NikonData/";
  File data = new File (path);
  String [] list = data.list();
  img = loadImage (path+list[list.length-1]);
  server.sendImage(rotatePImage(getReversePImage(img)));
}

public PImage getReversePImage( PImage image ) {
 PImage reverse = new PImage( image.width, image.height );
 for( int i=0; i < image.width; i++ ){
  for(int j=0; j < image.height; j++){
   reverse.set( image.width - 1 - i, j, image.get(i, j) );
  }
 }
 return reverse;
}

public PImage rotatePImage( PImage image ) {
  PImage rotated = new PImage( image.width, image.height );
  for( int i=0; i < image.width; i++ ){
   for(int j=0; j < image.height; j++) {
    rotated.set(i, j, image.get(image.width - 1 - i, image.height - 1 -j));
   }
  }
  return rotated;
}

public void stop() {
  super.stop();
}

  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "ImageDirectory2Syphon" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
