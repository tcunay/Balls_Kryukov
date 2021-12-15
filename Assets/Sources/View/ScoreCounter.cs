using UnityEngine;
using TMPro;
using Sources.Abstract;
using Sources.Root;

namespace Sources.View
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreCounter : CompositeEntity
    {
        private TMP_Text _text;
        private IScore _player;
        
        public override void Compose<T1>(T1 player)
        {
            _player = (IScore) player;
            
            _player.ScoreChanged += ChangeTextValue;
            
            _text = GetComponent<TMP_Text>();
            
            ChangeTextValue();
            
            Validator.Validate(_player == null);
        }

        private void Start()
        {
            ChangeTextValue();
        }

        private void ChangeTextValue()
        {
            _text.text = _player.Score.ToString();
        }
    }
}