using CALMario.Controllers;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CALMario
{

    public class GhostPlayerInputs
    {
        private List<MarioInputs> lastRun;
        private List<MarioInputs> thisRun;

        private static GhostPlayerInputs Instance = new GhostPlayerInputs();

        public static List<MarioInputs> LastRunInputs { get { return Instance.lastRun; } }
        public static List<MarioInputs> CurrentRunInputs { get { return Instance.thisRun; } }
        public static bool SpawnGhostMario { get; set; }

        private GhostPlayerInputs()
        {
            lastRun = new List<MarioInputs>();
            thisRun = new List<MarioInputs>();
        }

        public static void TransferInputs()
        {
            Instance.lastRun = new List<MarioInputs>(Instance.thisRun);
        }
    }
}
