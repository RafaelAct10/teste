﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LivroDeReceira.Exceptions {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceMensagemDeErro {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceMensagemDeErro() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LivroDeReceira.Exceptions.ResourceMensagemDeErro", typeof(ResourceMensagemDeErro).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O e-mail do usuário deve ser informado..
        /// </summary>
        public static string EMAIL_USUARIO_EMBRANCO {
            get {
                return ResourceManager.GetString("EMAIL_USUARIO_EMBRANCO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O e-mail do usuário é invalido..
        /// </summary>
        public static string EMAIL_USUARIO_INVALIDO {
            get {
                return ResourceManager.GetString("EMAIL_USUARIO_INVALIDO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Erro Desconhecido.
        /// </summary>
        public static string ERRO_DESCONHECIDO {
            get {
                return ResourceManager.GetString("ERRO_DESCONHECIDO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O nome do usuario não pode estar vazio..
        /// </summary>
        public static string NOME_USUARIO_EMBRANCO {
            get {
                return ResourceManager.GetString("NOME_USUARIO_EMBRANCO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A senha do usuário deve ser informada..
        /// </summary>
        public static string SENHA_USUARIO_EMBRANCO {
            get {
                return ResourceManager.GetString("SENHA_USUARIO_EMBRANCO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A senha deve contar no minimo 6 caracteres..
        /// </summary>
        public static string SENHA_USUARIO_MINIMO_SEIS_CARACTERES {
            get {
                return ResourceManager.GetString("SENHA_USUARIO_MINIMO_SEIS_CARACTERES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O telefone do usuário deve ser informado..
        /// </summary>
        public static string TELEFONE_USUARIO_EMBRANCO {
            get {
                return ResourceManager.GetString("TELEFONE_USUARIO_EMBRANCO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O telefone do usuário deve estar no formato (xx) x xxxx-xxxx.
        /// </summary>
        public static string TELEFONE_USUARIO_INVALIDO {
            get {
                return ResourceManager.GetString("TELEFONE_USUARIO_INVALIDO", resourceCulture);
            }
        }

        public static object Login_invalido { get; internal set; }
    }
}
