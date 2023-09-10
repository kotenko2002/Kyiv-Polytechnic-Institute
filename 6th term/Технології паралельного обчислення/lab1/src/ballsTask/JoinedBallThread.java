package ballsTask;

public class JoinedBallThread extends BallThread {
    private Thread threadToJoin;
    public JoinedBallThread(Ball ball, Thread threadToJoin) {
        super(ball);
        this.threadToJoin = threadToJoin;
    }

    @Override
    public void run() {
        try {
            this.threadToJoin.join();
        } catch (InterruptedException e) {
            super.run();
            return;
        }

        super.run();
    }
}
