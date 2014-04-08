using AForge;
using AForge.Imaging.Filters;
using AForge.Video.DirectShow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TO-DO
// - Namen van screen veranderen naar 'screen......'
// - Lockbitmap gebruiken
// - Timer zodat na lange tijd niet gebruikt hij weer op intro schermen gaat
// - Debug, 2D veld laten zien
namespace ProjectZ
{
    public partial class GameWindow : Form
    {
        private int screenHeight;
        private int screenWidth;
        private double introSpeed = 1;
        private double fadeIn;
        private double fadeOut;
        private List<Label> labelList = new List<Label>();

        double firstIntroTimerCount = 0;
        double secondIntroTimerCount = 0;
        double thirdIntroTimerCount = 0;
        double mainMenuTimerCount = 0;

        private const int STATUSINTRO = 0;
        private const int STATUSMAINMENU = 1;
        private const int STATUSHOWTOPLAY = 2;
        private const int STATUSSELECTDIFFICULTY = 3;
        private const int STATUSHIGHSCORE = 4;
        private const int STATUSPAUSE = 5;
        private const int STATUSEND = 6;
        private const int STATUSMAINGAME = 7;

        private int status;
        private int gameCounter;

        private Random random = new Random();
        private int coinFlip;
        private int PLAYER1COINFLIP = 1;
        private int PLAYER2COINFLIP = 2;

        private Boolean ballInGame = false;
        private Boolean lblInGameShow = false;

        private ArrayList availableCams = new ArrayList();

        private double easySpeed = 2;
        private double mediumSpeed = 3;
        private double hardSpeed = 10;

        private const String diffExplain = "Hier leggen we uit hoe moeilijk moeilijk is";
        private const String highScoreExplain = "Hier leggen we uit dat de Highscore nog niet geïmplementeerd is";

        private Webcam webcam;
        private FilterInfoCollection videoDevices;
        private Filter filter;
        private BlobExtractor blobExtractor;
        private CodeScanner codeScanner;
        private ArrayList visibleObjects;
        private Bitmap streamImage;
        private Bitmap drawArea;

        private PlayingField playingField;
        private Player player1;
        private Player player2;
        private Wall player1Wall;
        private Wall player2Wall;
        private Cannon player1Cannon;
        private Cannon player2Cannon;
        private Ball ball;

        private const int PLAYER1 = 1;
        private const int PLAYER2 = 2;
        private const int WALLPLAYER1 = 3;
        private const int WALLPLAYER2 = 4;
        private const int CANNONPLAYER1 = 5;
        private const int CANNONPLAYER2 = 6;

        public GameWindow()
        {
            status = STATUSINTRO;

            InitializeComponent();
            InitializeCanvas();
            InitializeButtons();
            InitializeGameElements();

            menuCheckTimer.Enabled = true;
            Intro();
            //startMenu();
        }

        private void InitializeGameElements()
        {
            Console.WriteLine("Init game elements");
            InitializeWebcams();
            InitializeCardRecognitionComponents();
            InitializeFieldComponents();
            Console.WriteLine("Init game elements end");
        }

        private void InitializeCardRecognitionComponents()
        {
            Console.WriteLine("ini card recog");
            filter = new Filter();
            blobExtractor = new BlobExtractor();
            codeScanner = new CodeScanner();
            Console.WriteLine("ini card recog end");
        }

        private void InitializeWebcams()
        {
            Console.WriteLine("ini webcams");
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            webcam = new Webcam();

            try
            {
                webcam.setVideoSource(videoDevices[2].MonikerString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("niet de goede webcam gevonden");
            }
            Console.WriteLine("ini webcams end");

        }

        private void InitializeFieldComponents()
        {
            Console.WriteLine("ini field components");
            player1 = new Player(1);
            player2 = new Player(2);
            // Wall en Cannon worden (nog) niet gebruikt
            player1Wall = new Wall();
            player2Wall = new Wall();
            player1Cannon = new Cannon();
            player2Cannon = new Cannon();
            ball = new Ball(new IntPoint(100, 100), 45);

            playingField = new PlayingField();
            Console.WriteLine("ini field components end");
        }

        private void InitializeButtons()
        {
            Console.WriteLine("ini buttons");
            // Add labels to Array
            labelList.Add(lblPlay);
            labelList.Add(lblQuit);
            labelList.Add(lblHowToPlay);
            labelList.Add(lblHighScore);
            labelList.Add(lblReturn);
            labelList.Add(lblPlay);
            labelList.Add(lblEasy);
            labelList.Add(lblMedium);
            labelList.Add(lblHard);
            labelList.Add(lblDifficultyExplaination);
            labelList.Add(lblHighScoreExplaination);
            labelList.Add(lblInGame);
            labelList.Add(lblMainMenu);

            // Turns off visibility
            foreach (Label lbl in labelList)
            {
                lbl.Visible = false;
                lbl.AutoSize = false;
                lbl.Text = String.Empty;
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.White;
                lbl.Font = new System.Drawing.Font("8BIT WONDER", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            }

            // Leftover labels who need to be altered
            lblReturn.Font = new System.Drawing.Font("8BIT WONDER", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblInGame.Font = new System.Drawing.Font("8BIT WONDER", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblInGame.BackColor = Color.Transparent;

            // Sets the size of the labels
            lblPlay.Size = new System.Drawing.Size(256, 60);
            lblHighScore.Size = new System.Drawing.Size(300, 110);
            lblHowToPlay.Size = new System.Drawing.Size(360, 110);
            lblQuit.Size = new System.Drawing.Size(230, 60);
            lblEasy.Size = new System.Drawing.Size(300, 60);
            lblMedium.Size = new System.Drawing.Size(400, 60);
            lblHard.Size = new System.Drawing.Size(300, 60);
            lblReturn.Size = new System.Drawing.Size(200, 60);
            lblInGame.Size = new System.Drawing.Size(400, 100);
            lblMainMenu.Size = new System.Drawing.Size(300, 110);

            // Location is based on the midpoint of the label, so minus 1/2 size
            lblPlay.Location = new System.Drawing.Point(350 - (int)lblPlay.Size.Width / 2, 450 - (int)lblPlay.Size.Height / 2);
            lblHighScore.Location = new System.Drawing.Point(350 - (int)lblHighScore.Size.Width / 2, 630 - (int)lblHighScore.Size.Height / 2);
            lblHowToPlay.Location = new System.Drawing.Point(1000 - (int)lblHowToPlay.Size.Width / 2, 450 - (int)lblHowToPlay.Size.Height / 2);
            lblQuit.Location = new System.Drawing.Point(1000 - (int)lblQuit.Size.Width / 2, 620 - (int)lblQuit.Size.Height / 2);
            lblEasy.Location = new System.Drawing.Point(300 - (int)lblEasy.Size.Width / 2, 503 - (int)lblEasy.Size.Height / 2);
            lblMedium.Location = new System.Drawing.Point(675 - (int)lblMedium.Size.Width / 2, 503 - (int)lblMedium.Size.Height / 2);
            lblHard.Location = new System.Drawing.Point(1050 - (int)lblHard.Size.Width / 2, 503 - (int)lblHard.Size.Height / 2);
            lblReturn.Location = new System.Drawing.Point(10, 650);
            lblInGame.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width/2) - (int)lblHard.Size.Width / 2, 100 - (int)lblHard.Size.Height / 2);
            lblMainMenu.Location = new System.Drawing.Point(450 - (int)lblHighScore.Size.Width / 2, 630 - (int)lblHighScore.Size.Height / 2);

            // Textures of the buttons
            lblHowToPlay.Text = "how to play";
            lblPlay.Text = "play";
            lblQuit.Text = "quit";
            lblHighScore.Text = "high score";
            lblEasy.Text = "easy";
            lblMedium.Text = "medium";
            lblHard.Text = "hard";
            lblReturn.Text = "back";
            lblMainMenu.Text = "main menu";
            lblDifficultyExplaination.Text = diffExplain;
            lblHighScoreExplaination.Text = highScoreExplain;

            // Sets the right Eventhandlers to the right labels
            lblPlay.Click += new System.EventHandler(this.enterDifficultyMenu);
            lblQuit.Click += new System.EventHandler(this.leaveGame);
            lblHighScore.Click += new System.EventHandler(this.enterHighScoreMenu);
            lblHowToPlay.Click += new System.EventHandler(this.enterHowToPlayMenu);
            lblReturn.Click += new System.EventHandler(this.returnClick);
            lblEasy.Click += new System.EventHandler(this.easyClick);
            lblMedium.Click += new System.EventHandler(this.mediumClick);
            lblHard.Click += new System.EventHandler(this.hardClick);
            lblMainMenu.Click += new System.EventHandler(this.returnToMainMenu);
            Console.WriteLine("ini buttons end");
        }

        private void InitializeCanvas()
        {
            Console.WriteLine("ini canvas");
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            pBoxGame.Height = screenHeight;
            pBoxGame.Width = screenWidth;
            pBoxGame.Location = new System.Drawing.Point(0, 0);
            Console.WriteLine("ini canvas ends");

        }
        // -------------- The Intro Sequence Begins Here ----------------------------------------------------------------
        private void Intro()
        {
            Console.WriteLine("ini intro");
            fadeIn = 20;
            fadeOut = 2 * fadeIn;
            startFirstIntro();
        }

        private void startMainMenu()
        {
            Console.WriteLine("ini timer main menu");
            mainMenuTimer.Interval = Convert.ToInt32(introSpeed);
            mainMenuTimer.Start();
        }

        private void startThirdIntro()
        {
            Console.WriteLine("ini third intro");
            thirdIntroTimer.Interval = Convert.ToInt32(introSpeed);
            thirdIntroTimer.Start();
        }

        private void startSecondIntro()
        {
            Console.WriteLine("ini second intro");
            secondIntroTimer.Interval = Convert.ToInt32(introSpeed);
            secondIntroTimer.Start();
        }

        private void startFirstIntro()
        {
            Console.WriteLine("ini first intro");
            firstIntroTimer.Interval = Convert.ToInt32(introSpeed);
            firstIntroTimer.Start();
        }

        private void firstIntroTick(object sender, EventArgs e)
        {
            firstIntroTimerCount = firstIntroTimerCount + introSpeed;
            if (firstIntroTimerCount <= fadeIn) {
                pBoxGame.Image = ChangeOpacity.change(Textures.getTexture("firstIntroScreen"), (float)((100 / fadeIn) * firstIntroTimerCount) / 100);
            }
            else if (firstIntroTimerCount <= fadeOut && firstIntroTimerCount > fadeIn)
            {
                float check = (float)(2-((100 / fadeIn) * firstIntroTimerCount) / 100);
                pBoxGame.Image = ChangeOpacity.change(Textures.getTexture("firstIntroScreen"), check);
            }
            else
            {
                firstIntroTimer.Stop();
                startSecondIntro();
                pBoxGame.Image.Dispose();
            }
        }

        private void secondIntroTick(object sender, EventArgs e)
        {
            secondIntroTimerCount = secondIntroTimerCount + introSpeed;
            if (secondIntroTimerCount <= fadeIn)
            {
                pBoxGame.Image = ChangeOpacity.change(Textures.getTexture("secondIntroScreen"), (float)((100 / fadeIn) * secondIntroTimerCount) / 100);
            }
            else if (secondIntroTimerCount <= fadeOut && secondIntroTimerCount > fadeIn)
            {
                float check = (float)(2 - ((100 / fadeIn) * secondIntroTimerCount) / 100);
                pBoxGame.Image = ChangeOpacity.change(Textures.getTexture("secondIntroScreen"), check);
            }
            else
            {
                secondIntroTimer.Stop();
                startThirdIntro();
                pBoxGame.Image.Dispose();
            }
        }

        private void thirdIntroTick(object sender, EventArgs e)
        {
            thirdIntroTimerCount = thirdIntroTimerCount + introSpeed;
            if (thirdIntroTimerCount <= fadeIn)
            {
                pBoxGame.Image = ChangeOpacity.change(Textures.getTexture("thirdIntroScreen"), (float)((100 / fadeIn) * thirdIntroTimerCount) / 100);
            }
            else if (thirdIntroTimerCount <= fadeOut && thirdIntroTimerCount > fadeIn)
            {
                float check = (float)(2 - ((100 / fadeIn) * thirdIntroTimerCount) / 100);
                pBoxGame.Image = ChangeOpacity.change(Textures.getTexture("thirdIntroScreen"), check);
            }
            else
            {
                thirdIntroTimer.Stop();
                startMainMenu();
                pBoxGame.Image.Dispose();
            }
        }

        private void mainMenuTick(object sender, EventArgs e)
        {
            mainMenuTimerCount = mainMenuTimerCount + introSpeed;
            if (mainMenuTimerCount <= fadeIn)
            {
                pBoxGame.Image = ChangeOpacity.change(Textures.getTexture("mainMenuBackground"), (float)((100 / fadeIn) * mainMenuTimerCount) / 100);
            }
            else
            {
                mainMenuTimer.Stop();
                Console.WriteLine("ini main menu");
                startMenu();
            }
        }

        // --------------------- The Intro Sequence End Here --------------------------------------------------------------

        private void startMenu()
        {
            status = STATUSMAINMENU;
            pBoxGame.Image = Textures.getTexture("mainMenuBackground");
        }
        private void menuCheckTick(object sender, EventArgs e)
        {
            switch (status)
            {
                case STATUSINTRO:
                    clearLabels();
                    break;

                case STATUSMAINMENU:
                    clearLabels();
                    lblPlay.Visible = true;
                    lblQuit.Visible = true;
                    lblHighScore.Visible = true;
                    lblHowToPlay.Visible = true;
                    break;

                case STATUSHOWTOPLAY:
                    clearLabels();
                    lblReturn.Visible = true;
                    break;

                case STATUSSELECTDIFFICULTY:
                    clearLabels();
                    lblEasy.Visible = true;
                    lblMedium.Visible = true;
                    lblHard.Visible = true;
                    lblDifficultyExplaination.Visible = true;
                    lblReturn.Visible = true;
                    break;

                case STATUSHIGHSCORE:
                    clearLabels();
                    lblReturn.Visible = true;
                    lblHighScoreExplaination.Visible = true;
                    break;

                case STATUSEND:
                    clearLabels();
                    lblQuit.Visible = true;
                    lblMainMenu.Visible = true;
                    break;

                case STATUSPAUSE:
                    clearLabels();
                    lblQuit.Visible = true;
                    lblMainMenu.Visible = true;
                    break;

                case STATUSMAINGAME:
                    clearLabels();
                    if (lblInGameShow)
                    {
                        lblInGame.Visible = true;
                    }
                    menuCheckTimer.Stop();
                    break;

                default:

                    break;
            }
        }

        private void clearLabels()
        {
            foreach (Label lbl in labelList)
            {
                lbl.Visible = false;
            }
        }

        private void videoStreamTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                visibleObjects = new ArrayList();
                EdgeKeeper.emptyEdges();

                
                visibleObjects.Add(playingField);

                // Add edges of playingfield to keeper
                playingField.addEdgesToKeeper();

                int widthCheck = webcam.getWidth();
                int heightCheck = webcam.getHeight();
                if (widthCheck != 0 && heightCheck != 0)
                {
                    drawArea = new Bitmap(webcam.getStreamImage(), widthCheck, heightCheck);
                    streamImage = webcam.getStreamImage();

                    pBoxGame.Image = drawArea;
                    
                    if (streamImage != null)
                    {
                        ArrayList cornerPoints = blobExtractor.extractBlob(filter.applyFilter(streamImage));
                        if (cornerPoints.Count > 0)
                        {
                            analyseImage(cornerPoints);
                        }
                    }

                    // Add ball to visibleobjectlist and moves it when ball is in game
                    if (ballInGame)
                    {
                        visibleObjects.Add(ball);
                        if (!ball.move())
                        {
                            sideEdgeCountered();
                        }
                    }

                    // TEKENEN
                    if (visibleObjects.Count > 0)
                    {
                        foreach (VisibleObject visObj in visibleObjects)
                        {
                            drawArea = visObj.draw(drawArea);
                        }
                    }
                }

            }
            catch (Exception h)
            {
                Console.WriteLine(h.StackTrace);
            }
        }

        private void sideEdgeCountered()
        {
            status = STATUSEND;
            menuCheckTimer.Start();
            // Links is player 1, rood
            if (ball.get2DPos().X < 500)
            {
                pBoxGame.Image = Textures.getTexture("blueWin");
            }
            // Rechts is player 2, blauw
            else
            {
                pBoxGame.Image = Textures.getTexture("redWin");
            }
            
        }

        private void analyseImage(ArrayList cornerPoints)
        {
            foreach (List<IntPoint> corners in cornerPoints)
            {
                QuadrilateralTransformation quadTransformation = new QuadrilateralTransformation(corners, 150, 150);
                Bitmap analysedImage = quadTransformation.Apply(streamImage);
                int cardValue = -1;
                if (analysedImage != null)
                {
                    cardValue = codeScanner.scan(analysedImage);
                    if (cardValue != -1)
                    {
                        recognize(cardValue, corners);
                    }
                }
            }
        }

        private Boolean contains(Object obj, ArrayList objectList)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                if (objectList[i].Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }

        private void recognize(int cardValue, List<IntPoint> corners)
        {
            switch (cardValue)
            {
                case PLAYER1:
                    player1.updatePosition(corners);
                    visibleObjects.Add(player1);
                    player1.addEdgesToKeeper();
                    break;
                case PLAYER2:
                    player2.updatePosition(corners);
                    visibleObjects.Add(player2);
                    player2.addEdgesToKeeper();
                    break;

                case WALLPLAYER1:
                    player1Wall.updatePosition(corners);
                    visibleObjects.Add(player1Wall);
                    player1Wall.addEdgesToKeeper();
                    break;

                case WALLPLAYER2:
                    player2Wall.updatePosition(corners);
                    visibleObjects.Add(player2Wall);
                    player2Wall.addEdgesToKeeper();
                    break;

                case CANNONPLAYER1:
                    player1Cannon.updatePosition(corners);
                    visibleObjects.Add(player1Cannon);
                    player1Cannon.addEdgesToKeeper();
                    break;

                case CANNONPLAYER2:
                    player2Cannon.updatePosition(corners);
                    visibleObjects.Add(player2Cannon);
                    player2Cannon.addEdgesToKeeper();
                    break;

                default:
                    Console.WriteLine("Default option, no action taken");
                    break;
            }
        }

        private void startGame()
        {
            status = STATUSMAINGAME;
            turnOnCam();
            StartInGameComponents();            
        }

        private void turnOnCam()
        {
            if (!webcam.isRunning() && webcam.hasVideoSource())
            {
                webcam.turnOn();
                videoStreamTimer.Start();
            }
        }

        private void StartInGameComponents()
        {
            gameCounter = 0;
            if (random.Next(1, 2) <= 1.5)
            {
                coinFlip = PLAYER1COINFLIP;
            }
            else
            {
                coinFlip = PLAYER2COINFLIP;
            }
            lblInGameShow = true;
            GameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            switch (gameCounter)
            {
                case 0:
                    lblInGame.Text = "Flipping a coin";
                    break;

                case 30:
                    if (coinFlip == PLAYER1COINFLIP)
                    {
                        lblInGame.Text = "Player 1 won the coinflip";
                    }
                    else
                    {
                        lblInGame.Text = "Player 2 won the coinflip";
                    }
                    break;

                case 40:
                    lblInGame.Text = "Ready?";
                    if (coinFlip == PLAYER1COINFLIP)
                    {
                        ball = new Ball(PointConverter.get3DPoint(new IntPoint(500, 500)), 0);
                    }
                    else
                    {
                        ball = new Ball(PointConverter.get3DPoint(new IntPoint(500, 500)), Math.PI);
                    }
                    break;

                case 50:
                    lblInGame.Text = "Set";
                    break;

                case 60:
                    lblInGame.Text = "GO!";
                    break;

                case 70:
                    ballInGame = true;
                    lblInGameShow = false;
                    GameTimer.Stop();
                    break;

                default:
                    break;
            }
            gameCounter += 1;
        }


    }
}


