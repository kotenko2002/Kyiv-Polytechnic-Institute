package ballsTask;

import javax.swing.*;
import java.awt.*;
import java.awt.geom.Ellipse2D;
import java.util.ArrayList;

public class BallCanvas extends JPanel {
    public static final int XSIZE = 20;
    public static final int YSIZE = 20;

    public ArrayList<Integer[]> holesPosition = new ArrayList<>(4);
    private ArrayList<Ball> balls = new ArrayList<>();

    public void add(Ball b){
        this.balls.add(b);
    }
    @Override
    public void paintComponent(Graphics g){
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D)g;

        for(int i=0; i<balls.size();i++){
            Ball b = balls.get(i);
            b.draw(g2);
        }

        for(Integer[] holePosition : this.holesPosition) {
            g2.setColor(Color.RED);
            g2.fill(new Ellipse2D.Double(holePosition[0], holePosition[1], XSIZE, YSIZE));
        }
    }
}

