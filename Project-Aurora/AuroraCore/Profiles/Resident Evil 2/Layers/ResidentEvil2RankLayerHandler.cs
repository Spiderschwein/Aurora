﻿using Aurora.Devices.Layout.Layouts;
using Aurora.EffectsEngine;
using Aurora.Profiles.ResidentEvil2.GSI;
using Aurora.Profiles.ResidentEvil2.GSI.Nodes;
using Aurora.Settings;
using Aurora.Settings.Layers;
using System.Drawing;

namespace Aurora.Profiles.ResidentEvil2.Layers
{
    public class ResidentEvil2RankLayerHandlerProperties : LayerHandlerProperties2Color<ResidentEvil2RankLayerHandlerProperties>
    {
        public ResidentEvil2RankLayerHandlerProperties() : base() { }

        public ResidentEvil2RankLayerHandlerProperties(bool assign_default = false) : base(assign_default) { }

        public override void Default()
        {
            base.Default();
            this._Sequence = new KeySequence(new KeyboardKeys[] {
                            KeyboardKeys.ONE, KeyboardKeys.TWO, KeyboardKeys.THREE, KeyboardKeys.FOUR, KeyboardKeys.FIVE,
                            KeyboardKeys.SIX, KeyboardKeys.SEVEN, KeyboardKeys.EIGHT, KeyboardKeys.NINE
                        });
        }

    }

    public class ResidentEvil2RankLayerHandler : LayerHandler<ResidentEvil2RankLayerHandlerProperties>
    {
        public ResidentEvil2RankLayerHandler() : base()
        {
            _ID = "ResidentEvil2Rank";
        }
        public override EffectLayer Render(IGameState state)
        {
            EffectLayer keys_layer = new EffectLayer("Resident Evil 2 - Rank");

            if (state is GameState_ResidentEvil2)
            {
                GameState_ResidentEvil2 re2state = state as GameState_ResidentEvil2;

                if (re2state.Player.Status != Player_ResidentEvil2.PlayerStatus.OffGame && re2state.Player.Rank != 0)
                {
                    keys_layer.Set(Properties.Sequence.keys[re2state.Player.Rank - 1], Color.White);
                }
            }
            return keys_layer;
        }
    }
}