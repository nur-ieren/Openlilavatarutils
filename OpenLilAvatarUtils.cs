using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace nur_ieren
{
    /// <summary>
    /// ヒエラルキーで右クリックしたオブジェクトを対象にして lilAvatarUtils を開く。
    /// Assets/nur_ieren/ 直下に置くだけで動作します(Editor フォルダ不要)。
    /// lilAvatarUtils への参照は持たず、リフレクションで呼び出します。
    /// </summary>
    public static class OpenLilAvatarUtils
    {
        private const string MenuPath = "GameObject/Open lilAvatarUtils";
        private const int MenuPriority = -1000; // かなり上に表示

        [MenuItem(MenuPath, false, MenuPriority)]
        private static void Open()
        {
            var target = Selection.activeGameObject;
            if (target == null) return;

            var windowType = FindWindowType();
            if (windowType == null)
            {
                EditorUtility.DisplayDialog("nur_ieren", "lilAvatarUtils が見つかりませんでした。導入されているか確認してください。", "OK");
                return;
            }

            var window = EditorWindow.GetWindow(windowType);
            window.Show();
            window.Focus();

            AssignTarget(window, target);
            window.Repaint();
        }

        [MenuItem(MenuPath, true)]
        private static bool Validate()
        {
            var go = Selection.activeGameObject;
            return go != null && !EditorUtility.IsPersistent(go);
        }

        private static Type FindWindowType()
        {
            Type fallback = null;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] types;
                try { types = asm.GetTypes(); }
                catch (ReflectionTypeLoadException e) { types = e.Types.Where(t => t != null).ToArray(); }

                foreach (var t in types)
                {
                    if (!typeof(EditorWindow).IsAssignableFrom(t) || t.IsAbstract) continue;
                    if (t.FullName == "jp.lilxyzw.avatarutils.AvatarUtils") return t;
                    if (fallback == null && t.Namespace != null &&
                        t.Namespace.ToLowerInvariant().Contains("avatarutils") &&
                        t.Name.ToLowerInvariant().Contains("avatarutils"))
                        fallback = t;
                }
            }
            return fallback;
        }

        private static void AssignTarget(EditorWindow window, GameObject target)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var fields = window.GetType().GetFields(flags);

            var field =
                fields.FirstOrDefault(f => f.FieldType == typeof(GameObject) &&
                                           new[] { "avatar", "m_avatar", "target", "root", "gameObject" }
                                               .Contains(f.Name, StringComparer.OrdinalIgnoreCase))
                ?? fields.FirstOrDefault(f => f.FieldType == typeof(GameObject));

            if (field != null) { field.SetValue(window, target); return; }

            var tField = fields.FirstOrDefault(f => f.FieldType == typeof(Transform));
            if (tField != null) tField.SetValue(window, target.transform);
        }
    }
}
