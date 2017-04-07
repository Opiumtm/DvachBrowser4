using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace DvachBrowser4.Core.Serialization
{
    /// <summary>
    /// Провайдер бинарной сериализации.
    /// </summary>
    public sealed class BinaryDataContractSerializationProvider : ISerializationProvider
    {
        /// <summary>
        /// Получить сериализатор для типа.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <returns>Сериализатор.</returns>
        public ISerializer<T> GetSerializer<T>()
        {
            return new BinarySerializer<T>();
        }

        private class BinarySerializer<T> : ISerializer<T>
        {
            private static readonly DataContractSerializer Serializer = new DataContractSerializer(typeof(T));

            /// <summary>
            /// Сериализовать объект.
            /// </summary>
            /// <param name="src">Исходный объект.</param>
            /// <param name="stream">Поток.</param>
            /// <returns>Таск.</returns>
            public Task Serialize(T src, Stream stream)
            {
                void Run()
                {
                    using (var wr = XmlDictionaryWriter.CreateBinaryWriter(stream, new XmlDictionary(), new XmlBinaryWriterSession(), false))
                    {
                        Serializer.WriteObject(wr, src);
                        wr.Flush();
                    }
                }

                return Task.Run(new Action(Run));
            }

            /// <summary>
            /// Десериализовать объект.
            /// </summary>
            /// <param name="stream">Поток.</param>
            /// <returns>Таск.</returns>
            public Task<T> Deserialize(Stream stream)
            {
                T Run()
                {
                    using (var rd = XmlDictionaryReader.CreateBinaryReader(stream, new XmlDictionary(), XmlDictionaryReaderQuotas.Max))
                    {
                        return (T)Serializer.ReadObject(rd);
                    }
                }

                return Task.Run(new Func<T>(Run));
            }
        }
    }
}