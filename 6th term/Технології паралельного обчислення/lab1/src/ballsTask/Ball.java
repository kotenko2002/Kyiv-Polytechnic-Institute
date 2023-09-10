package ballsTask;

import java.awt.*;
import java.awt.geom.Ellipse2D;
import java.util.Random;

class Ball {
    private final BallCanvas canvas;
    private static final int XSIZE = 20;
    private static final int YSIZE = 20;
    private int x = 0;
    private int y = 0;
    private int dx = 2;
    private int dy = 2;
    private Color color = Color.GRAY;

    public Ball(BallCanvas c){
        this.canvas = c;
        this.initRandomPosition();
    }

    public Ball(BallCanvas c, Color color){
        this.canvas = c;
        this.color = color;
        this.initRandomPosition();
    }

    public Ball(BallCanvas c, Color color, int x, int y) {
        this.canvas = c;
        this.color = color;
        this.x = x;
        this.y = y;
    }

    public void initRandomPosition() {
        x = new Random().nextInt(this.canvas.getWidth());
        y = new Random().nextInt(this.canvas.getHeight());
    }

    public void draw (Graphics2D g2){
        g2.setColor(this.color);
        g2.fill(new Ellipse2D.Double(x,y,XSIZE,YSIZE));
    }

    public void removeMeFromCanvas() {
        this.canvas.remove(this);
    }

    public boolean interceptedHole() {
        int ballX = this.x + XSIZE / 2; int bally = this.y + YSIZE / 2;
        int ballRadius = XSIZE / 2;

        for (Integer[] holeCords: this.canvas.holes) {
            int holeX = holeCords[0] + BallCanvas.XSIZE / 2; int holey = holeCords[1] + BallCanvas.YSIZE / 2;
            int holeRadius = BallCanvas.XSIZE / 2;
            double d = Math.sqrt(Math.pow((ballX - holeX), 2) + Math.pow((bally-holey), 2)) - 5;

            if (d <= ballRadius - holeRadius || d <= holeRadius - ballRadius || d <= holeRadius + ballRadius) {
                return true;
            }
        }

        return false;
    }

    public void move() {
        x += dx;
        y += dy;

        if(x<0) {
            x = 0;
            dx = -dx;
        }

        if(x+XSIZE >= this.canvas.getWidth()){
            x = this.canvas.getWidth()-XSIZE;
            dx = -dx;
        }
        if(y<0) {
            y=0;
            dy = -dy;
        }
        if(y+YSIZE >= this.canvas.getHeight()){
            y = this.canvas.getHeight()-YSIZE;
            dy = -dy;
        }

        this.canvas.repaint();
    }
}