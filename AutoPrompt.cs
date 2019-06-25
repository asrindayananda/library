using System;
using System.Reflection;

namespace Project_2.Subsystems
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AutoPrompt : Attribute
    {
        private string _PromptText;
        public string PromptText
        {
            get { return _PromptText; }
            set { _PromptText = value; }
        }

        public AutoPrompt(string promptText)
        {
            _PromptText = promptText;
        }

        private static string _Prompt = "Enter the {0}: ";
        private static void CreateWorker<datatype>(ref datatype obj, Type t)
        {
            if (t == typeof(object))
                return;

            CreateWorker<datatype>(ref obj, t.BaseType);
            foreach (MemberInfo mi in t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (mi.MemberType == MemberTypes.Field)
                {
                    AutoPrompt ap = Attribute.GetCustomAttribute(mi, typeof(AutoPrompt)) as AutoPrompt;
                    if (ap == null)
                        continue;

                    FieldInfo fi = mi as FieldInfo;
                    string fieldPrompt = ap.PromptText;

                    #region byte support
                    if (fi.FieldType == typeof(byte))
                    {
                        byte val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (byte.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region char support
                    else if (fi.FieldType == typeof(char))
                    {
                        char val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (char.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region double support
                    else if (fi.FieldType == typeof(double))
                    {
                        double val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (double.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region decimal support
                    else if (fi.FieldType == typeof(decimal))
                    {
                        decimal val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (decimal.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region float support
                    else if (fi.FieldType == typeof(float))
                    {
                        float val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (float.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region int support
                    else if (fi.FieldType == typeof(int))
                    {
                        int val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (int.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region long support
                    else if (fi.FieldType == typeof(long))
                    {
                        long val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (long.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region sbyte support
                    else if (fi.FieldType == typeof(sbyte))
                    {
                        sbyte val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (sbyte.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region short support
                    else if (fi.FieldType == typeof(short))
                    {
                        short val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (short.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region string support
                    else if (fi.FieldType == typeof(string))
                    {
                        Console.Write(_Prompt, fieldPrompt);
                        fi.SetValue(obj, Console.ReadLine());
                    }
                    #endregion
                    #region uint support
                    else if (fi.FieldType == typeof(uint))
                    {
                        uint val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (uint.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region ulong support
                    else if (fi.FieldType == typeof(ulong))
                    {
                        ulong val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (ulong.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    #region ushort support
                    else if (fi.FieldType == typeof(ushort))
                    {
                        ushort val;
                        do
                        {
                            Console.Write(_Prompt, fieldPrompt);
                        } while (ushort.TryParse(Console.ReadLine(), out val) == false);
                        fi.SetValue(obj, val);
                    }
                    #endregion
                    else
                        throw new InvalidOperationException(string.Format("{0} is of unsupported type in {1}", fi.Name, fi.ReflectedType));
                }
            }
        }

        public static datatype Create<datatype>() where datatype : new()
        {
            datatype dt = new datatype();
            CreateWorker<datatype>(ref dt, typeof(datatype));

            return dt;
        }
    }
}
