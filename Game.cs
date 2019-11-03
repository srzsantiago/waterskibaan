using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;


namespace Waterskibaan
{
    public class Game
    {
        

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;
        public delegate void LijnenVerplaatstHandler();
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        public Waterskibaan waterskibaan { get; set; }
        public WachtrijStarten wachtrijStarten { get; set; }
        public InstructieGroep instructieGroep { get; set; }
        public WachtrijInstructie wachtrijinstructie { get; set; }
        public Lijn MovementAt { get; set; }

        private int count=0;
        private Random rand = new Random();



        public DispatcherTimer dispatcherTimer;

        public void Initialize()
        {
            waterskibaan = new Waterskibaan();
            wachtrijStarten = new WachtrijStarten();
            instructieGroep = new InstructieGroep();
            wachtrijinstructie = new WachtrijInstructie();

            TestOpdracht12();
            NieuweBezoeker += OnNieuweBezoeker;//3
            InstructieAfgelopen += OnInstructieAflopen;//20
            LijnenVerplaatst += OnLijnenVerplaatst;//4

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        private void TestOpdracht12()
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    instructieGroep.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            //}
            //for (int i = 0; i < 50; i++)
            //{
            //    wachtrijinstructie.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            //}
            //for (int i = 0; i < 20; i++)
            //{
            //    wachtrijStarten.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            //}

        }


    private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            if (count % 1 == 0) {
                
                if (waterskibaan.Kabel.IsStartPositieLeeg())
                {
                    try { 
                    Sporter sp = wachtrijStarten.SportersVerlatenRij(1)[0];
                    sp.Skies = new Skies();
                    sp.Zwemvest = new Zwemvest();
                    waterskibaan.SporterStart(sp);
                    Console.WriteLine(waterskibaan.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            if (count % 3 == 0)
            {
                try
                {
                    NieuweBezoeker?.Invoke(new NieuweBezoekerArgs(new Sporter(MoveCollection.GetWillekeurigeMoves())));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("COUNT 3");
                    Console.WriteLine(ex.Message);
                }
                
            }
            if (count % 4 == 0)
            {
                try
                {
                    LijnenVerplaatst?.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("count 4");
                    Console.WriteLine(ex.Message);
                }
            }

            if (count % 20 == 0)
            {
                try
                {
                    List<Sporter> Sporters = instructieGroep.SportersVerlatenRij(instructieGroep.MAX_LENGTE_RIJ);
                    InstructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(Sporters));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("count 20");
                    Console.WriteLine(ex.Message);
                }
 
            }
            
            if (count % 10 == 0)
            {
                Console.WriteLine("=====================INVENTARIS==================");
                Console.WriteLine($"WachtrijInstructie: {wachtrijinstructie.ToString()}");
                Console.WriteLine($"Instructiegroep: {instructieGroep.ToString()}");
                Console.WriteLine($"WachtrijStarten: {wachtrijStarten.ToString()}");
                Console.WriteLine("==================================================");
            }
            count += 1;
        }

        private void OnLijnenVerplaatst()
        {
            waterskibaan.VerplaatsKabel();

            if(rand.Next(1,4) == 1)
            {
                //choice random sporter from the kabel and a random move to execute. 
                int random;
                do
                {
                    random = rand.Next(0, waterskibaan.Kabel._lijnen.Count());
                    if (random <= waterskibaan.Kabel._lijnen.Count || waterskibaan.Kabel._lijnen.ElementAt(random).Sporter != null)
                    {
                        MovementAt = waterskibaan.Kabel._lijnen.ElementAt(random);
                        MovementAt.Sporter.HuidigeMove = MovementAt.Sporter.Moves[rand.Next(0, MovementAt.Sporter.Moves.Count)];
                        MovementAt.Sporter.Punten = MovementAt.Sporter.HuidigeMove.Move();
                    }
                } while (!(random <= waterskibaan.Kabel._lijnen.Count) || waterskibaan.Kabel._lijnen.ElementAt(random).Sporter == null);
                
                
                
            }
            
        }

        private void OnNieuweBezoeker(NieuweBezoekerArgs e)
        {
            wachtrijinstructie.SporterNeemPlaatsInRij(e.Sporter);
        }
        private void OnInstructieAflopen(InstructieAfgelopenArgs e)
        {
            foreach (var sp in e.Sporters)
            {
                wachtrijStarten.SporterNeemPlaatsInRij(sp);
            }

            List<Sporter> Sporters = wachtrijinstructie.SportersVerlatenRij(Math.Min(wachtrijinstructie.GetAlleSporters().Count, instructieGroep.MAX_LENGTE_RIJ));

            foreach (var sp in Sporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sp);
            }
        }

    }
}
