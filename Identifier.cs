using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Engine
    {
        class Identifier
        {
            string _id;
            static string _idLast = " ";
            public static EntityDict _entities;

            public string ID { get { return _id; } }

            public Identifier(Entity ent)
            {
                _id = _idLast;
                IdIncrement();
                _entities.Add(_id, ent);
            }

            public static Entity GetFromIdList(string key)
                => _entities.Get(key);
            

            public static void IdIncrement()
            {
                IdIncrement(_idLast.Length - 1);
            }

            public static void IdIncrement(int index)
            {
                bool flag = false;
                char changed = _idLast[index];
                changed = (char)(changed + 1);

                if (changed == 127)
                {
                    changed = (char)32;
                    flag = true;
                }

                _idLast = _idLast.Remove(index, 1);
                _idLast = _idLast.Insert(index, changed.ToString());

                if (flag)
                    if (index == 0)
                        _idLast = _idLast.Insert(0, "!");

                    else 
                        IdIncrement(index - 1);
            }
        }
    }
}