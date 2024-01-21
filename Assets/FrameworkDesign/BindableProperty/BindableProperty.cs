using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    // һ���������ݰ󶨵�ר�÷�����.
    // ����+���ݱ���¼��ļ����塣
    public class BindableProperty<T> where T :IEquatable<T>
    {
        private T mValue;

        // �����ݱ仯ʱ,�����ⲿί�д��롣
        public T Value { 
            get => mValue;
            set
            {
                if(!mValue.Equals(value))
                {
                    mValue = value;
                    OnValueChanged?.Invoke(value);
                }
            }
        }

        public Action<T> OnValueChanged;
    }
}

