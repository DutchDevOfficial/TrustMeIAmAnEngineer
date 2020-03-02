using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{
    /// <summary>
    /// parent klasse voor alle grafische elementen die klikbaar zijn -> vb nodig in main menu
    /// </summary>
    class GUIelements
    {
        private Texture2D GUITexture;
        private Rectangle GUIRect;
        private string _assetName;
        private bool _isHovering;

        public string AssetName { get => AssetName1; set => AssetName1 = value; }
        public string AssetName1 { get => _assetName; set => _assetName = value; }

        //bijhouden op welk element er gedrukt wordt -> delegate omdat er een event op volgt
        public delegate void ElementClicked(string element);
        public event ElementClicked ClickEvent;
        
        //als aangemaakt, de naam wordt doorgegeven zodat de juiste resources worden gevonden
        public GUIelements(string assetName)
        {
            this.AssetName = assetName;
        }

        public void Load(ContentManager content)
        {
            GUITexture = content.Load<Texture2D>(AssetName);
            GUIRect = new Rectangle(0, 0, GUITexture.Width, GUITexture.Height);
        }

        public void Update()
        {
            _isHovering = false;

            //if de muis is in de GUIrect en de linkermuisknop wordt ingedrukt
            if (GUIRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //als geklinkt houdt de naam bij -> zo weten we welk element ingedrukt is
                ClickEvent(AssetName);
            }

            //if de muis is in de GUIrect dan IsHover == true 
            if (GUIRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
            {
                _isHovering = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (_isHovering)
            {
                colour = Color.Gray;
            }

            spriteBatch.Draw(GUITexture, GUIRect, colour);
        }

        //centreren van GUIelement      height en width moeten de scherm grote zijn
        public void CenterElement(int height, int width)
        {
            //de helft van het scherm delen door 2, min de grote van de texturen delen door 2 -> geeft gecentreerd beeld
            GUIRect = new Rectangle((width / 2) - (this.GUITexture.Width / 2), (height / 2) - (this.GUITexture.Height / 2), this.GUITexture.Width, this.GUITexture.Height);
        }

        //verplaatsen van GUIelement        x en y zijn de verplaatsings parameters
        public void MoveElement(int x, int y)
        {
            GUIRect = new Rectangle(GUIRect.X += x, GUIRect.Y += y, GUIRect.Width, GUIRect.Height);
        }
    }
}
