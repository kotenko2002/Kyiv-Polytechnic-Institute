package ballsTask;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class BounceFrame extends JFrame {
    public static final int WIDTH = 450;
    public static final int HEIGHT = 350;
    public BallCanvas canvas;

    public BounceFrame() {
        this.setSize(WIDTH, HEIGHT);
        this.setTitle("Bounce program");

        this.canvas = new BallCanvas();
        System.out.println("In Frame Thread name = " + Thread.currentThread().getName());
        Container content = this.getContentPane();
        content.add(this.canvas, BorderLayout.CENTER);

        JPanel buttonPanel = new JPanel();
        buttonPanel.setBackground(Color.lightGray);

        JButton buttonStart = new JButton("Add ball");
        JButton buttonPriorityTest = new JButton("Priority test");
        JButton buttonJoinTest = new JButton("Join test");

        buttonStart.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                for (int i = 0; i < 5; i++) {
                    Ball ball = new Ball(canvas);
                    canvas.add(ball);

                    BallThread thread = new BallThread(ball);
                    thread.start();
                }
            }
        });

        buttonPriorityTest.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                for (int i = 0; i < 1000; i++) {
                    Ball ball = new Ball(canvas, Color.BLUE, 0, 0);
                    canvas.add(ball);

                    BallThread thread = new BallThread(ball);
                    thread.setPriority(Thread.MIN_PRIORITY);
                    thread.start();
                }

                var ball = new Ball(canvas, Color.RED, 0, 0);
                canvas.add(ball);

                BallThread thread = new BallThread(ball);
                thread.setPriority(Thread.MAX_PRIORITY);
                thread.start();
            }
        });

        buttonJoinTest.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Ball b1 = new Ball(canvas, Color.YELLOW);
                Ball b2 = new Ball(canvas, Color.BLUE);

                canvas.addRange(new Ball[] { b1, b2 });

                var thread1 = new BallThread(b1);
                var thread2 = new JoinedBallThread(b2, thread1);

                thread1.start();
                thread2.start();
            }
        });

        buttonPanel.add(buttonStart);
        buttonPanel.add(buttonPriorityTest);
        buttonPanel.add(buttonJoinTest);

        content.add(buttonPanel, BorderLayout.SOUTH);
    }
}