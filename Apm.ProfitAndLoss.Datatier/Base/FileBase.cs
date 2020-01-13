using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Apm.ProfitAndLoss.Datatier.Base
{
    public class FileBase
    {
        private string _fullName;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (IsValid(value))
                {
                    _fullName = value;
                }
            }
        }

        public FileBase(string fullName)
        {
            _fullName = fullName;
        }

        public string GetContent()
        {
            try
            {
                return File.ReadAllText(_fullName);
            }
            catch
            {
                return null;
            }
        }

        public void SetContent(string content)
        {
            try
            {
                File.WriteAllText(_fullName, content);
            }
            catch
            {
                throw;
            }
        }

        #region Utils
        private bool IsValid(string cad)
        {
            return !string.IsNullOrEmpty(cad) && !string.IsNullOrWhiteSpace(cad);
        }
        #endregion
    }
}
