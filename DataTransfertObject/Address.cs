using System.ComponentModel.DataAnnotations;

namespace DataTransfertObject
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string NumeroVoieEtablissement { get; set; }
        public string TypeVoieEtablissement { get; set; }
        public string LibelleVoieEtablissement { get; set; }
        public string LibelleCommuneEtablissement { get; set; }
        public string CodeCommuneEtablissement { get; set; }
        public string LibellePaysEtrangerEtablissement { get; set; }
    }
}
