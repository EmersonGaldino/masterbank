using System.Runtime.Serialization;

namespace master.bank.infraestructure.persistence.configuration.exceptions;

public class TableNameNotImplementedDomainException : System.Exception
{
    #region Methods
    public TableNameNotImplementedDomainException(string message) : base(message) { }
    public TableNameNotImplementedDomainException() : base() { }
    private TableNameNotImplementedDomainException(SerializationInfo info, StreamingContext context) { }
    #endregion
}