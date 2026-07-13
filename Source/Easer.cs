using Monocle;

namespace Celeste.Mod.OverlayOpacity;

public class Easer
{
    private float _target;
    private float _last;
    private float _duration;
    private float _time;
    public float Ease => (_target + (_last - _target) * (_time / _duration));

    public float Target
    {
        get => _target;
        set
        {
            _last = Ease;
            _target = value;
            _time = _duration;
        }
    }

    public float Duration
    {
        get => _duration;
        set
        {
            if (_time != 0) _time += (value-_duration);
            if (_time < 0) _time = 0;
            _duration = value;
        }
    }

    public float Update()
    {
        if (_time == 0) return 1;
        _time -= Engine.DeltaTime;
        if (_time < 0) _time = 0;
        return 1-(_time / _duration);
    }

    public Easer(float target, float duration)
    {
        _target = target;
        _last = target;
        _duration = duration;
        _time = 0;
    }
}