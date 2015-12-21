import processing.opengl.*;
import codeanticode.syphon.*;
import ddf.minim.*;


SyphonServer server;

String syphonServerName = "Latest Image in Directory Syphon";
PImage img;

void setup() {
  size(10, 10, P3D);
  server = new SyphonServer(this, syphonServerName);
}

void draw() {
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

