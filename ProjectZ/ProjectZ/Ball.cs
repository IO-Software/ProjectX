using AForge;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    class Ball : VisibleObject
    {
        private IntPoint currentPos2D;
        private IntPoint currentPos3D;

        private double speed = 5;
        private double speedSaved;
        private double angle;

        private Boolean hitRightOrLeftWall = false;

        public Ball(IntPoint startPos3D, double angle)
        {
            this.angle = angle;
            currentPos3D = startPos3D;
            updateCurrentPos2D(startPos3D);
        }

        private void updateCurrentPos2D(IntPoint update) 
        {
            currentPos2D = PointConverter.get2DPoint(update);
        }

        private void updateCurrentPos3D(IntPoint update)
        {
            currentPos3D = PointConverter.get3DPoint(update);
        }

        public Boolean detectEdge(Edge edge)
        {
            // Dit werkt alleen maar in 2D
            IntPoint edgePosA = edge.getEdgePointA_2D();
            IntPoint edgePosB = edge.getEdgePointB_2D();
            // Punt d is een voorspelling van het punt waar punt C de volgende stap gaat zijn
            AForge.IntPoint nextStepC = new IntPoint(Convert.ToInt32(currentPos2D.X + Math.Cos(angle) * speed), Convert.ToInt32(currentPos2D.Y + Math.Sin(angle) * speed));

            float denominator = ((edgePosB.X - edgePosA.X) * (nextStepC.Y - currentPos2D.Y)) - ((edgePosB.Y - edgePosA.Y) * (nextStepC.X - currentPos2D.X));
            float numerator1 = ((edgePosA.Y - currentPos2D.Y) * (nextStepC.X - currentPos2D.X)) - ((edgePosA.X - currentPos2D.X) * (nextStepC.Y - currentPos2D.Y));
            float numerator2 = ((edgePosA.Y - currentPos2D.Y) * (edgePosB.X - edgePosA.X)) - ((edgePosA.X - currentPos2D.X) * (edgePosB.Y - edgePosA.Y));

            if (denominator == 0)
            {
                return numerator1 == 0 && numerator2 == 0;
            }

            float r = numerator1 / denominator;
            float s = numerator2 / denominator;

            return (r >= 0 && r <= 1) && (s >= 0 && s <= 1);
        }

        public void bounce(Edge edge)
        {
            // Dit is ook alleen maar in 2D
            Double dX = edge.getEdgePointA_2D().X - edge.getEdgePointB_2D().X;
            Double dY = edge.getEdgePointA_2D().Y - edge.getEdgePointB_2D().Y;

            DoublePoint edgeVector = new DoublePoint(dX, dY);

            // Breuken in de ATan functie werken niet goed, dus bij deze een helper
            double Atanhelper = edgeVector.Y / edgeVector.X;
            double angleWall = Math.Atan(Atanhelper);
            double normalEdge = angleWall + (Math.PI * 0.5);
            double angleSpeedVector = angle;
            double angleDifference = normalEdge - angleSpeedVector;
            double angleSpeedVectorNew = angleSpeedVector - Math.PI + (2 * angleDifference);

            angle = angleSpeedVectorNew;

            currentPos2D.X = Convert.ToInt32(currentPos2D.X + Math.Cos(angle) * speed);
            currentPos2D.Y = Convert.ToInt32(currentPos2D.Y + Math.Sin(angle) * speed);
            updateCurrentPos3D(currentPos2D);
        }

        public Bitmap draw(Bitmap image)
        {
            try
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    System.Drawing.Point currentPosPoint = new System.Drawing.Point(currentPos3D.X, currentPos3D.Y);
                    Size size = new Size(10,10);
                    Rectangle rect = new Rectangle(currentPosPoint,size);
                    graphics.DrawEllipse(new Pen (Color.Purple, 5), rect);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
            return image;
        }

        public void updatePosition(List<IntPoint> update) 
        {
            // NOTHING WILL HAPPEN HERE
        }

        public void setSpeedBall(double newSpeed)
        {
            Console.WriteLine("Speed of ball has been set. Speed is: " + newSpeed);
            speed = newSpeed;
            Console.WriteLine("Speed of ball hopefully changed: " + speed);
        }

        public Boolean move()
        {
            hitRightOrLeftWall = false;
            intersects();
            if (hitRightOrLeftWall)
            {
                return false;
            }
            else
            {
                currentPos2D.X = Convert.ToInt32(currentPos2D.X + Math.Cos(angle) * speed);
                currentPos2D.Y = Convert.ToInt32(currentPos2D.Y + Math.Sin(angle) * speed);
                updateCurrentPos3D(currentPos2D);
                return true;
            }
        }

        public void intersects()
        {
            Boolean intersect = false;
            foreach (Edge edge in EdgeKeeper.getEdges())
            {
                intersect = detectEdge(edge);
                if (intersect)
                {
                    if (edge.Equals(PlayingField.getLeft()) || edge.Equals(PlayingField.getRight()))
                    {
                        hitRightOrLeftWall = true;
                    }
                    else
                    {
                        bounce(edge);
                    }
                }
            }
        }

        public void setPosition(IntPoint setPos2D)
        {
            currentPos2D = setPos2D;
            currentPos3D = PointConverter.get3DPoint(setPos2D);
        }

        public void pauseBall()
        {
            speedSaved = speed;
            this.speed = 0;
        }

        public void resumeBall() 
        {
            speed = speedSaved;
        }

        public IntPoint get2DPos()
        {
            return currentPos2D;
        }

    }
}
