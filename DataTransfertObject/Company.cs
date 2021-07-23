using System.ComponentModel.DataAnnotations;

namespace DataTransfertObject
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Siren { get; set; }
        public string Nic { get; set; }
        public string DateCreationEtablissement { get; set; }
        public string DenominationUniteLegale { get; set; }
        public string ActivitePrincipaleUniteLegale { get; set; }
        public string DenominationUsuelle1UniteLegale { get; set; }
        public string NomenclatureActivitePrincipaleUniteLegale { get; set; }
        public string SigleUniteLegale { get; set; }
        public string CategorieJuridiqueUniteLegale { get; set; }
        public string TrancheEffectifsUniteLegale { get; set; }
        public Address AdresseEtablissement { get; set; }
    }
}
