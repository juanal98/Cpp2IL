﻿using System;
using Cpp2IL.Analysis.ResultModels;
using Iced.Intel;

namespace Cpp2IL.Analysis.Actions
{
    /// <summary>
    /// Action for a simple reg->reg move
    /// </summary>
    public class RegToRegMoveAction : BaseAction
    {
        private IAnalysedOperand? beingMoved;
        private string originalReg;
        private string newReg;
        
        public RegToRegMoveAction(MethodAnalysis context, Instruction instruction) : base(context, instruction)
        {
            originalReg = Utils.GetRegisterNameNew(instruction.Op1Register);
            newReg = Utils.GetRegisterNameNew(instruction.Op0Register);
            beingMoved = context.GetOperandInRegister(originalReg);

            context.SetRegContent(newReg, beingMoved);
        }

        public override Mono.Cecil.Cil.Instruction[] ToILInstructions()
        {
            //No-op
            return new Mono.Cecil.Cil.Instruction[0];
        }

        public override string? ToPsuedoCode()
        {
            return null;
        }

        public override string ToTextSummary()
        {
            return $"Copies {beingMoved} from {originalReg} into {newReg}";
        }
    }
}