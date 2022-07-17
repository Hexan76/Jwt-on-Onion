namespace Data.Common
{
    /// <summary>
    /// This Class Define Base Model Properties
    /// </summary>
    public abstract class BaseModel
    {
        private Guid _id;
        ///// <summary>
        ///// Guid Creating when Set on Null
        ///// </summary>
        public Guid ID { get { return _id; } set => _id = (value == Guid.Empty) ? Guid.NewGuid() : value; }
    }
}
