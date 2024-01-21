using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    // 一个用于数据绑定的专用泛型类.
    // 数据+数据变更事件的集合体。
    public class BindableProperty<T> where T :IEquatable<T>
    {
        private T mValue;

        // 在数据变化时,调用外部委托代码。
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

