﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gp1
{
    class Logo
    {
        public Vector2 pos;
        public int stopX;
        public int stopY;
        public Texture2D tex;
        public Logo(Texture2D tex, Vector2 pos, int stopX, int stopY)
        {
            this.tex = tex;
            this.pos = pos;
            this.stopX = stopX;
            this.stopY = stopY;
        }
        public void Update()
        {
            if (pos.X < stopX && pos.Y < stopY)
            {
                pos.X = pos.X + 1;
                pos.Y = pos.Y + 1;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
        }
    }
}
