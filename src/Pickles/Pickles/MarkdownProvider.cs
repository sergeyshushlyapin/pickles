﻿// #region License
// 
// 
// /*
//     Copyright [2011] [Jeffrey Cameron]
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// */
// #endregion

namespace PicklesDoc.Pickles
{
    public class MarkdownProvider
    {
        private readonly MarkdownDeep.Markdown markdown;

        public MarkdownProvider()
        {
            this.markdown = new MarkdownDeep.Markdown { ExtraMode = true, SafeMode = true };
        }

        public virtual string Transform(string text)
        {
            string transform = this.markdown.Transform(text);

            transform = transform.Replace("&nbsp;", string.Empty);

            return transform;
        }
    }
}
