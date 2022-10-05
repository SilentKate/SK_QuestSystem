namespace QuestSystem.Scripts.Runtime.DataBase
{
    public interface IQuestSourceDataBase
    {
        QuestDataSource GetDataSource(string id);
    }
}