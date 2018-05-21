using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProgramiranjeASP.DataLayer;

namespace WebProgramiranjeASP.BusinessLayer
{
    public class OperationManager
    {
        // Klasa OperationManager sluzi za centralizovani rad sa Operationma.
        // Klasa treba da sadrzi zajednicki kod koji je potreban za izvrsavanje bilo koje operacije.
        // U ovom malom primeru zajednicki deo je:
        // - objekat klase BaseEntities koji se pravi samo jednom u konsrtuktoru OperationManager i prosledjuje operacjijama,
        // - obrada izuzetaka.
        // U slozenijem slucaju menadzer Operation bi mogao da radi npr. sledece:
        // - Proveru da li treba executeti operaciju na osnovu kriterijuma koji mogu na neki nacin biti zadati trajno ili privremeno,
        //   npr. privremeno se nekom korsniku onemogucava update, insert, delete u vezi nekog od mogucih poslova.
        // - Upravljanje redom za cekanje u kojem stoje operacije koje treba izvsiti.
        //      1. stavljanje Operation u red za cekanje na izvrsenje u slucaju velikog broja Operation, odnosno opterecenja servera
        //      2. izvrsavanje Operation iz reda za cekanje po prioritetu Operation, ili prioritetu korisnika cije su operacije, u slucaju da ima vise Operation u redu za cekanje
        //   Upravljanje redom za cekanje od starne OperationManager dolazi u obzir u slucaju pisanja serverske aplikacije koja nema takvu podrsku,
        //   tj. ne dolazi u obzir za projekat tipa "Web Aplikacija".


        // Klasa OperationManager je singleton klasa, sto znaci da je obezbedjeno da moze da se napravi samo jedan objekat te klase.
        // Taj objekat pravi sama klasa i zato ima samo privatni konstruktor.
        // Postoji svojstvo koje se zove "Singleton" koje sluzi za dohvatanje objekta klase.
        // Objekat se pravi u trenutku kad se prvi put pokusa dohvatanje objekta preko svojstava "Singleton"
        // i to na bezbedan nacin i u slucaju koriscenja vise thread-ova koji pokusaju istovremeno da dohvate objekat klase.
        // To se postize koriscenjem dvostrukog lock-a.

        #region Singleton
        private OperationManager() { }
        private static volatile OperationManager singleton;
        private static object syncRoot = new object();

        public static OperationManager Singleton
        {
            get
            {
                if (OperationManager.singleton == null)
                {
                    lock (OperationManager.syncRoot)
                    {
                        if (OperationManager.singleton == null)
                            OperationManager.singleton = new OperationManager();
                    }
                }
                return OperationManager.singleton;
            }
        }
        #endregion

        private BaseEntities entities = new BaseEntities();

        public OperationResult executeOperation(Operation op)
        {
            try
            {
                return op.execute(this.entities);
            }
            catch(Exception e)
            {
                OperationResult obj = new OperationResult();
                obj.Status = false;
                return obj;
            }
        }

    }
}
