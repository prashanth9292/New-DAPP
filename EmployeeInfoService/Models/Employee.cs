using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EmployeeInfoService.Models
{
    [Table("Employees")]
    [DataContract]
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int employeeId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int EmployeeId
        {
            get { return employeeId; }
            set
            {
                employeeId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmployeeId)));
            }
        }

        private string employeeName;

        [MaxLength(30)]
        [DataMember]
        [Required]
        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                employeeName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmployeeName)));
            }
        }

        private DateTime dateOfBirth;

        [DataMember]
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateOfBirth)));
            }
        }

        private string currentAddress;

        [MaxLength(150)]
        [DataMember]
        [Required]
        public string CurrentAddress
        {
            get { return currentAddress; }
            set
            {
                currentAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAddress)));
            }
        }

        private string permanentAddress;

        [MaxLength(150)]
        [DataMember]
        public string PermanentAddress
        {
            get { return permanentAddress; }
            set {
                permanentAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PermanentAddress)));
            }
        }

        private string contactNo;

        [MaxLength(10)]
        [DataMember]
        [Required]
        public string ContactNo
        {
            get { return contactNo; }
            set
            {
                contactNo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContactNo)));
            }
        }

        private int? managerId; //type int? allows int to be null (nullable int)

        [DataMember]
        public int? ManagerId
        {
            get { return managerId; }
            set
            {
                managerId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ManagerId)));
            }
        }



    }
}
