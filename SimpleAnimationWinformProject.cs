public partial class PrzestrzenUkladuSlonecznego : Form
    {
        //zmienne katowe
        float kat_obrotu_ziemi;
        float kat_obrotu_ksiezyca;
        
        //zmienne przyrostu katow
        float wielkosc_zmiany_obr_ziemi=0.05F;
        float wielkosc_zmiany_obr_ksiez=0.05F;

        //stale
        //promien slonca
        const int R_Slonca = 50;
        //promien ziemi
        const int R_Ziemi = 25;
        //promien ksiezyca
        const int R_Ksiez = 5;

        //deklaracja zmiennych torow cial niebieskich
        int tor_ziemi;
        int tor_ksiezyca;

        public PrzestrzenUkladuSlonecznego()
        {
            InitializeComponent();
            this.Left = 10;
            this.Top = 10;

            //ustawienie wysokosci i szerokosci screenu
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width*0.7F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height*0.7f);

            //ustawienie koloru tla
            this.BackColor = Color.RoyalBlue;

            //zablokowanie zmiany rozwiarow width i height
            this.SetAutoSizeMode(System.Windows.Forms.AutoSizeMode.GrowAndShrink);

            //wylaczenia minimalizacji i maksymalizacji okna
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            tor_ziemi = this.Width / 5;
            tor_ksiezyca = this.Width / 12;

        }

        private void PrzestrzenUkladuSlonecznego_Paint(object sender, PaintEventArgs e)
        {
            
            //narysowanie elipsy w kształcie okregu oraz wypelnienie jej czerwonym kolorem
            //nastepnie ustawienie obiektu okregu na srodku ekranu 
            //oraz ustawienie wielkosci okregu na szer i wys
            e.Graphics.FillEllipse(Brushes.Red, this.Width/2 - R_Slonca,
                this.Height/2 - R_Slonca,2*R_Slonca,2*R_Slonca);
            
            //wyznaczenie poczatkowego polozenia ziemi
            float x_ziemi = (float)(this.Width / 2 + tor_ziemi*Math.Cos(kat_obrotu_ziemi));
            float y_ziemi = (float)(this.Height/2 + tor_ziemi*Math.Sin(kat_obrotu_ziemi));

            e.Graphics.FillEllipse(Brushes.LimeGreen,x_ziemi-R_Ziemi,y_ziemi-R_Ziemi,
                2*R_Ziemi,2*R_Ziemi);

            //wyznaczenie poczatkowego polozenia ksiezyca
            float x_ksiezyca = (float)(x_ziemi + tor_ksiezyca * Math.Cos(kat_obrotu_ksiezyca));
            float y_ksiezyca = (float)(y_ziemi + tor_ksiezyca*Math.Sin(kat_obrotu_ksiezyca));

            e.Graphics.FillEllipse(Brushes.LightYellow,x_ksiezyca-R_Ksiez,y_ksiezyca-R_Ksiez,
                2*R_Ksiez,2*R_Ksiez);




        }

        private void ZegarUkladuSlonecznego_Tick(object sender, EventArgs e)
        {
            this.ZegarUkladuSlonecznego.Enabled = true;
            this.kat_obrotu_ziemi = this.kat_obrotu_ziemi + this.wielkosc_zmiany_obr_ziemi;
            if (kat_obrotu_ziemi >= 360F)
                 this.kat_obrotu_ziemi = 0;
            
            this.kat_obrotu_ksiezyca = this.kat_obrotu_ksiezyca - this.wielkosc_zmiany_obr_ksiez;
            if (kat_obrotu_ksiezyca >= 360F)
            
                this.kat_obrotu_ksiezyca = 0;
            
            this.Invalidate();
        }
    }
