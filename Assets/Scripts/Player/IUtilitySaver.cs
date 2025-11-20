namespace Player
{
    public interface IUtilitySaver
    {
        bool TalkedWithPoisonMan { get; set; }
        bool MineralDelivered { get; set; }
        bool WarehouseDoorOpen { get; set; }
    }
}