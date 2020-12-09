public interface INeighbors
{
    int CheckingNeighbors(int xPosition, int yPosition);
    void GetNeighborWeight(int xPosition, int yPosition);
    void GetVisitedNeighbor(int xPosition, int yPosition, bool condition);
    void GetWeight(int xPosition, int yPosition, bool condition);
}