﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiniarAlgebra
{
    /// <Name>      Matrix of doubles for Liniar Algebra            </Name>
    /// <Version>           0.1a Pre release                        </Version>
    /// <FileName>          DoubleMatrix.cs                         </FileName>
    /// <ClassName>         DoubleMatrix                            </ClassName>
    /// <Creator>***************************************************************
    ///     <Name>          Yanir Taflev                            </Name>
    ///     <Email>         yanirta@gmail.com                       </Email>
    /// </Creator>**************************************************************
    /// <Guidance>
    ///     <Name>                                                  </Name>
    ///     <Email>                                                 </Email>
    /// </Guidance>
    /// <Institution>
    /// </Institution>
    /// <Date>              Aug. - 2009                             </Date>
    /// <License>
    /// This class library is free to use as long as it used unmodified, including the credits above.
    /// For modifications please contact with the creator to get an approval.
    /// </License>
    /// <summary>
    /// This class implements all the necessary for double typed matrix for Liniar Algebra
    /// as to be expected from a matrix structure.
    /// </summary>
    /// <References>
    /// </References>
    /// <SpecialThanks></SpecialThanks> 
    public class DoubleMatrix : Matrix<double>, ICloneable
    {
        #region C'tors
        public DoubleMatrix(int i_RowsAsColumns)
            : this(i_RowsAsColumns, i_RowsAsColumns)
        { }

        public DoubleMatrix(int i_Rows, int i_Columns) :
            base(i_Rows, i_Columns, new DoubleCalculator())
        { }

        public DoubleMatrix(double[,] i_dMatrix)
            : base(i_dMatrix, new DoubleCalculator())
        { }

        public DoubleMatrix(Matrix<double> i_baseMatrix)
            : base(i_baseMatrix)
        { }

        #endregion

        #region Operators

        public static DoubleMatrix operator +(DoubleMatrix i_LeftHand, DoubleMatrix i_RightHand)
        {
            return new DoubleMatrix(i_LeftHand.PlusOperator(i_RightHand));
        }

        public static DoubleMatrix operator *(DoubleMatrix i_LeftHand, DoubleMatrix i_RightHand)
        {
            return new DoubleMatrix(i_LeftHand.MultiplyOperator(i_RightHand));
        }

        public static DoubleMatrix operator *(DoubleMatrix i_LeftHand, double i_RightHand)
        {
            return new DoubleMatrix(i_LeftHand.MultiplyOperator(i_RightHand));
        }

        public static DoubleMatrix operator /(DoubleMatrix i_LeftHand, double i_RightHand)
        {
            return new DoubleMatrix(i_LeftHand.DivisionByScalarOperator(i_RightHand));
        }

        public static DoubleMatrix operator -(DoubleMatrix i_LeftHand, DoubleMatrix i_RightHand)
        {
            return new DoubleMatrix(i_LeftHand.MinusOperator(i_RightHand));
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return new DoubleMatrix(InnerMatrix);
        }

        #endregion

        public bool Inverse()
        {
            if (RowsCount != ColumnsCount)
            {
                return false;
            }
            return inv.rmatrixinverse(ref m_Matrix, RowsCount);
        }
    }

    internal class DoubleCalculator : ICalculator<Double>
    {
        #region ICalculator<double> Members

        public double Add(double i_LeftOperator, double i_RightOperator)
        {
            return i_LeftOperator + i_RightOperator;
        }

        public double Sub(double i_LeftOperator, double i_RightOperator)
        {
            return i_LeftOperator - i_RightOperator;
        }

        public double Multiply(double i_LeftOperator, double i_RightOperator)
        {
            return i_LeftOperator * i_RightOperator;
        }

        public double Division(double i_LeftOperator, double i_RightOperator)
        {
            return i_LeftOperator / i_RightOperator;
        }

        public double Zero()
        {
            return 0.0;
        }

        public double One()
        {
            return 1.0;
        }

        public double ToDouble(double i_ValueToConvert)
        {
            return i_ValueToConvert; //No convertion needed here
        }

        public double FromDouble(double i_ValueToConvert)
        {
            return i_ValueToConvert;
        }

        #endregion
    }
}
