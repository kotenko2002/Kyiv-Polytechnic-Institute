package ballsTask;

public class BallThread extends Thread {
    private Ball ball;

    public BallThread(Ball ball){
        this.ball = ball;
    }

    @Override
    public void run(){
        try{
            for(int i = 1; i < 1_000_000; i++) {
                ball.move();
                Thread.sleep(5);

                System.out.println("Thread name = " + Thread.currentThread().getName());

                if(ball.interceptedHole()) {
                    ball.removeMeFromCanvas();
                    return;
                }
            }
        } catch(InterruptedException ex) {}
    }
}

