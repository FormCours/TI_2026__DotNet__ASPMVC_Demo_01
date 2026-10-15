using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPMVC_01_Intro.Controllers
{
    public class CitationController : Controller
    {
        public static List<string> UneListeQuiReprendDixCitationsDeChuckNorris = [
            "Chuck Norris a déjà compté jusqu'à l'infini. Deux fois.",
            "Les larmes de Chuck Norris guérissent du cancer, mais malheureusement, il n'a jamais pleuré.",
            "Chuck Norris ne porte pas de montre. Il décide de l'heure qu'il est.",
            "Certains professionnels portent un pyjama Superman. Superman porte un pyjama Chuck Norris.",
            "Chuck Norris a été mordu par un cobra royal. Après cinq jours d'agonie atroce, le cobra est mort.",
            "Un jour, Chuck Norris a perdu son alliance. Depuis, c'est le bordel dans l'espace, on appelle ça des astéroïdes.",
            "Chuck Norris peut diviser par zéro.",
            "Quand Chuck Norris fait des pompes, il ne se soulève pas, il pousse la Terre vers le bas.",
            "Google ne cherche pas Chuck Norris, c'est Chuck Norris qui trouve Google.",
            "Chuck Norris a déjà gagné un tournoi de poker avec des cartes Pokémon."
        ];

        public IActionResult ChuckNorris()
        {
            var uneVariableQuiVeutDireCeQuelleVeutDire = Random.Shared.Next(0, UneListeQuiReprendDixCitationsDeChuckNorris.Count);
            var laCitationChoisieDansLaListe = UneListeQuiReprendDixCitationsDeChuckNorris[uneVariableQuiVeutDireCeQuelleVeutDire];

            ViewData["UneValeurSousFormeDeChaineDeCaractère"] = laCitationChoisieDansLaListe;
            return View();
        }
    }
}
