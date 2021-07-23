using DataLayer;
using DataTransfertObject;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CompanyRepository : Repository<Company>
    {
        public new IEnumerable<Company> GetAll()
        {
            StockContext dbContext = new StockContext();
            return dbContext.Companies.Select(c => new Company
            {
                Siren = c.Siren,
                Nic = c.Nic,
                DateCreationEtablissement = c.DateCreationEtablissement,
                DenominationUniteLegale = c.DenominationUniteLegale,
                ActivitePrincipaleUniteLegale = c.ActivitePrincipaleUniteLegale,
                DenominationUsuelle1UniteLegale = c.DenominationUsuelle1UniteLegale,
                NomenclatureActivitePrincipaleUniteLegale = c.NomenclatureActivitePrincipaleUniteLegale,
                SigleUniteLegale = c.SigleUniteLegale,
                CategorieJuridiqueUniteLegale = c.CategorieJuridiqueUniteLegale,
                TrancheEffectifsUniteLegale = c.TrancheEffectifsUniteLegale,
                AdresseEtablissement = new Address
                {
                    NumeroVoieEtablissement = c.AdresseEtablissement.NumeroVoieEtablissement,
                    TypeVoieEtablissement = c.AdresseEtablissement.TypeVoieEtablissement,
                    LibelleVoieEtablissement = c.AdresseEtablissement.LibelleVoieEtablissement,
                    LibelleCommuneEtablissement = c.AdresseEtablissement.LibelleCommuneEtablissement,
                    CodeCommuneEtablissement = c.AdresseEtablissement.CodeCommuneEtablissement,
                    LibellePaysEtrangerEtablissement = c.AdresseEtablissement.LibellePaysEtrangerEtablissement
                }
            });
        }
    }
}
