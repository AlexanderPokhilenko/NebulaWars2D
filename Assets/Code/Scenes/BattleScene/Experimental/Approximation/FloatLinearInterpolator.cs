namespace Code.Scenes.BattleScene.Experimental.Approximation
{
    public class FloatLinearInterpolator : AbstractLinearInterpolator<float>
    {
        public FloatLinearInterpolator(float time) :base(time)
        { }

        protected override float GetValue(float oldValue, float newValue, float percent) =>
            oldValue + (newValue - oldValue) * percent;
    }
}
