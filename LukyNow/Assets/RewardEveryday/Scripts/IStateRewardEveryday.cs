

public interface IStateRewardEveryday 
{
    void Received(RewardEverydayView view);
    void UnRecived(RewardEverydayView view);
    void NextReceived(RewardEverydayView view);
}
