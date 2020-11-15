using Reception.Contracts.Common;

namespace Reception.Contracts.Reception
{
    public class ClientDto
    {
        ///<summary> 
        /// Идентификатор клиента 
        /// </summary>
        public int Id { get; set; }

        ///<summary> 
        /// Телефон 
        /// </summary>
        public string Phone { get; set; }

        ///<summary> 
        /// Адрес электронной почты 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Тип клиента 
        /// </summary>
        public EnumType Type { get; set; }

        /// <summary>
        /// Имя 
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Фамилия 
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Отчество 
        /// </summary>
        public string middleName { get; set; }

        ///<summary> 
        /// Наименование организации 
        /// </summary>
        public string Name { get; set; }

        ///<summary> 
        /// ИНН 
        ///</summary>
        public string Inn { get; set; }

        ///<summary> 
        /// КПП 
        /// </summary>
        public string Kpp { get; set; }
    }
}