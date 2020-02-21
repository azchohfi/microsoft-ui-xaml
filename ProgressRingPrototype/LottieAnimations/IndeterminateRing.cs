﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Microsoft.UI.Xaml.Controls;
using System;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace ProgressRingPrototype
{
    // Name:        IndeterminateRing
    // Frame rate:  60 fps
    // Frame count: 120
    // ===========
    // Property bindings:
    // Vector4 "Background" as Color
    // Vector4 "Foreground" as Color
    // Scalar "StrokeWidth"
    sealed class IndeterminateRing : DependencyObject, IAnimatedVisualSource
    {
        CompositionPropertySet _themeProperties;

        public Color Background
        {
            get { return (Color)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Color), typeof(IndeterminateRing),
                new PropertyMetadata(Color.FromArgb(0xFF, 0xD3, 0xD3, 0xD3), new PropertyChangedCallback(OnBackgroundChanged)));

        private static void OnBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = ((IndeterminateRing)d);
            if (me._themeProperties != null)
            {
                me._themeProperties.InsertVector4("Background", ColorAsVector4(me.Background));
            }
        }

        public Color Foreground
        {
            get { return (Color)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Color), typeof(IndeterminateRing),
                new PropertyMetadata(Color.FromArgb(0xFF, 0x00, 0x78, 0xD7), new PropertyChangedCallback(OnForegroundChanged)));

        private static void OnForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = ((IndeterminateRing)d);
            if (me._themeProperties != null)
            {
                me._themeProperties.InsertVector4("Foreground", ColorAsVector4(me.Foreground));
            }
        }

        public float StrokeWidth
        {
            get { return (float)GetValue(StrokeWidthProperty); }
            set { SetValue(StrokeWidthProperty, value); }
        }

        public static readonly DependencyProperty StrokeWidthProperty =
            DependencyProperty.Register("StrokeWidth", typeof(float), typeof(IndeterminateRing),
                new PropertyMetadata((float)2.0, new PropertyChangedCallback(OnStrokeWidthChanged)));

        private static void OnStrokeWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = ((IndeterminateRing)d);
            if (me._themeProperties != null)
            {
                me._themeProperties.InsertScalar("StrokeWidth", me.StrokeWidth);
            }
        }

        public CompositionPropertySet GetThemeProperties(Compositor compositor)
        {
            return EnsureThemeProperties(compositor);
        }

        static Vector4 ColorAsVector4(Color color) => new Vector4(color.R, color.G, color.B, color.A);

        CompositionPropertySet EnsureThemeProperties(Compositor compositor)
        {
            if (_themeProperties is null)
            {
                _themeProperties = compositor.CreatePropertySet();
                _themeProperties.InsertVector4("Background", ColorAsVector4(Background));
                _themeProperties.InsertVector4("Foreground", ColorAsVector4(Foreground));
                _themeProperties.InsertScalar("StrokeWidth", StrokeWidth);
            }
            return _themeProperties;
        }

        public IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor, out object diagnostics)
        {
            diagnostics = null;
            EnsureThemeProperties(compositor);

            if (AnimatedVisual.IsRuntimeCompatible())
            {
                return
                    new AnimatedVisual(
                        compositor,
                        _themeProperties
                        );
            }

            return null;
        }

        static void StartProgressBoundAnimation(
            CompositionObject target,
            string animatedPropertyName,
            CompositionAnimation animation,
            ExpressionAnimation controllerProgressExpression)
        {
            target.StartAnimation(animatedPropertyName, animation);
            var controller = target.TryGetAnimationController(animatedPropertyName);
            controller.Pause();
            controller.StartAnimation("Progress", controllerProgressExpression);
        }

        sealed class AnimatedVisual : IAnimatedVisual
        {
            // Animation duration: 2.000 seconds.
            const long c_durationTicks = 20000000;
            readonly Compositor _c;
            readonly ExpressionAnimation _reusableExpressionAnimation;
            readonly CompositionPropertySet _themeProperties;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0;
            StepEasingFunction _holdThenStepEasingFunction;
            ContainerVisual _root;
            ExpressionAnimation _rootProgress;
            ExpressionAnimation _scalarExpressionAnimation;
            CompositionColorBrush _themeColor_Foreground_0;
            CompositionColorBrush _themeColor_Foreground_1;

            void BindProperty(
                CompositionObject target,
                string animatedPropertyName,
                string expression,
                string referenceParameterName,
                CompositionObject referencedObject)
            {
                _reusableExpressionAnimation.ClearAllParameters();
                _reusableExpressionAnimation.Expression = expression;
                _reusableExpressionAnimation.SetReferenceParameter(referenceParameterName, referencedObject);
                target.StartAnimation(animatedPropertyName, _reusableExpressionAnimation);
            }

            // Traversal order: 4
            // ShapeGroup: Ellipse
            CompositionContainerShape ContainerShape_0()
            {
                var result = _c.CreateContainerShape();
                result.TransformMatrix = new Matrix3x2(5, 0, 0, 5, 50, 50);
                // Ellipse Path
                result.Shapes.Add(SpriteShape_0());
                return result;
            }

            // Traversal order: 17
            // Layer (Shape): Radial
            CompositionContainerShape ContainerShape_1()
            {
                var result = _c.CreateContainerShape();
                result.TransformMatrix = new Matrix3x2(5, 0, 0, 5, 50, 50);
                // Transforms: Radial
                result.Shapes.Add(ContainerShape_2());
                return result;
            }

            // Traversal order: 19
            // Layer (Shape): Radial
            // Transforms for Radial
            CompositionContainerShape ContainerShape_2()
            {
                var result = _c.CreateContainerShape();
                var shapes = result.Shapes;
                // Ellipse Path / ShapeGroup: Ellipse B
                shapes.Add(SpriteShape_1());
                // Ellipse Path / ShapeGroup: Ellipse A
                shapes.Add(SpriteShape_2());
                StartProgressBoundAnimation(result, "RotationAngleInDegrees", RotationAngleInDegreesScalarAnimation_0_to_900(), _rootProgress);
                return result;
            }

            // Traversal order: 31
            CubicBezierEasingFunction CubicBezierEasingFunction_0()
            {
                return _cubicBezierEasingFunction_0 = _c.CreateCubicBezierEasingFunction(new Vector2(0.166999996F, 0.166999996F), new Vector2(0.833000004F, 0.833000004F));
            }

            // Traversal order: 8
            // ShapeGroup: Ellipse / Transforms: Radial BG / Layer (Shape): Radial BG
            // Ellipse Path
            // Ellipse Path.EllipseGeometry
            CompositionEllipseGeometry Ellipse_7_0()
            {
                var result = _c.CreateEllipseGeometry();
                result.Radius = new Vector2(7, 7);
                return result;
            }

            // Traversal order: 23
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path / ShapeGroup: Ellipse B
            // Ellipse Path.EllipseGeometry
            CompositionEllipseGeometry Ellipse_7_1()
            {
                var result = _c.CreateEllipseGeometry();
                result.TrimEnd = 0.5F;
                result.Radius = new Vector2(7, 7);
                StartProgressBoundAnimation(result, "TrimStart", TrimStartScalarAnimation_0_to_0p5(), RootProgress());
                return result;
            }

            // Traversal order: 47
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path / ShapeGroup: Ellipse A
            // Ellipse Path.EllipseGeometry
            CompositionEllipseGeometry Ellipse_7_2()
            {
                var result = _c.CreateEllipseGeometry();
                result.Radius = new Vector2(7, 7);
                StartProgressBoundAnimation(result, "TrimEnd", TrimEndScalarAnimation_0_to_0p5(), _rootProgress);
                return result;
            }

            // Traversal order: 29
            StepEasingFunction HoldThenStepEasingFunction()
            {
                var result = _holdThenStepEasingFunction = _c.CreateStepEasingFunction();
                result.IsFinalStepSingleFrame = true;
                return result;
            }

            // Traversal order: 41
            // Opacity0
            ScalarKeyFrameAnimation Opacity0ScalarAnimation_0_to_1()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(0, 0, _holdThenStepEasingFunction);
                result.InsertKeyFrame(0.5F, 1, _holdThenStepEasingFunction);
                return result;
            }

            // Traversal order: 57
            // Opacity0
            ScalarKeyFrameAnimation Opacity0ScalarAnimation_1_to_0()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(0, 1, _holdThenStepEasingFunction);
                result.InsertKeyFrame(0.5F, 0, _holdThenStepEasingFunction);
                return result;
            }

            // Traversal order: 0
            // The root of the composition.
            ContainerVisual Root()
            {
                var result = _root = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Progress", 0);
                result.Children.InsertAtTop(ShapeVisual_0());
                return result;
            }

            // Traversal order: 35
            ExpressionAnimation RootProgress()
            {
                var result = _rootProgress = _c.CreateExpressionAnimation("_.Progress");
                result.SetReferenceParameter("_", _root);
                return result;
            }

            // Traversal order: 61
            // Layer (Shape): Radial
            // Transforms: Radial
            // Rotation
            ScalarKeyFrameAnimation RotationAngleInDegreesScalarAnimation_0_to_900()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(0, 0, _holdThenStepEasingFunction);
                result.InsertKeyFrame(0.5F, 450, _cubicBezierEasingFunction_0);
                result.InsertKeyFrame(1, 900, _cubicBezierEasingFunction_0);
                return result;
            }

            // Traversal order: 15
            ExpressionAnimation ScalarExpressionAnimation()
            {
                var result = _scalarExpressionAnimation = _c.CreateExpressionAnimation("_theme.StrokeWidth");
                result.SetReferenceParameter("_theme", _themeProperties);
                return result;
            }

            // Traversal order: 2
            ShapeVisual ShapeVisual_0()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(100, 100);
                var shapes = result.Shapes;
                // ShapeGroup: Ellipse / Transforms: Radial BG / Layer (Shape): Radial BG
                shapes.Add(ContainerShape_0());
                // Layer (Shape): Radial
                shapes.Add(ContainerShape_1());
                return result;
            }

            // Traversal order: 6
            // ShapeGroup: Ellipse / Transforms: Radial BG / Layer (Shape): Radial BG
            // Ellipse Path
            CompositionSpriteShape SpriteShape_0()
            {
                var result = _c.CreateSpriteShape(Ellipse_7_0());
                result.StrokeBrush = ThemeColor_Background();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StartAnimation("StrokeThickness", ScalarExpressionAnimation());
                return result;
            }

            // Traversal order: 21
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path
            CompositionSpriteShape SpriteShape_1()
            {
                var result = _c.CreateSpriteShape(Ellipse_7_1());
                result.StrokeBrush = ThemeColor_Foreground_0();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StartAnimation("StrokeThickness", _scalarExpressionAnimation);
                return result;
            }

            // Traversal order: 45
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path
            CompositionSpriteShape SpriteShape_2()
            {
                var result = _c.CreateSpriteShape(Ellipse_7_2());
                result.StrokeBrush = ThemeColor_Foreground_1();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 4;
                result.StartAnimation("StrokeThickness", _scalarExpressionAnimation);
                return result;
            }

            // Traversal order: 27
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path / ShapeGroup: Ellipse B
            // Ellipse Path.EllipseGeometry
            // TrimStart
            StepEasingFunction StepThenHoldEasingFunction()
            {
                var result = _c.CreateStepEasingFunction();
                result.IsInitialStepSingleFrame = true;
                return result;
            }

            // Traversal order: 10
            // ShapeGroup: Ellipse / Transforms: Radial BG / Layer (Shape): Radial BG
            // Ellipse Path
            // Color bound to theme property value: Background
            CompositionColorBrush ThemeColor_Background()
            {
                var result = _c.CreateColorBrush();
                BindProperty(result, "Color", "ColorRGB(_theme.Background.W,_theme.Background.X,_theme.Background.Y,_theme.Background.Z)", "_theme", _themeProperties);
                return result;
            }

            // Traversal order: 37
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path / ShapeGroup: Ellipse B
            // Color bound to theme property value: Foreground
            CompositionColorBrush ThemeColor_Foreground_0()
            {
                var result = _themeColor_Foreground_0 = _c.CreateColorBrush();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Opacity0", 0);
                _reusableExpressionAnimation.ClearAllParameters();
                _reusableExpressionAnimation.Expression = "ColorRGB(_theme.Foreground.W * my.Opacity0,_theme.Foreground.X,_theme.Foreground.Y,_theme.Foreground.Z)";
                _reusableExpressionAnimation.SetReferenceParameter("my", propertySet);
                _reusableExpressionAnimation.SetReferenceParameter("_theme", _themeProperties);
                result.StartAnimation("Color", _reusableExpressionAnimation);
                StartProgressBoundAnimation(propertySet, "Opacity0", Opacity0ScalarAnimation_0_to_1(), _rootProgress);
                return result;
            }

            // Traversal order: 53
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path / ShapeGroup: Ellipse A
            // Color bound to theme property value: Foreground
            CompositionColorBrush ThemeColor_Foreground_1()
            {
                var result = _themeColor_Foreground_1 = _c.CreateColorBrush();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Opacity0", 1);
                _reusableExpressionAnimation.ClearAllParameters();
                _reusableExpressionAnimation.Expression = "ColorRGB(_theme.Foreground.W * my.Opacity0,_theme.Foreground.X,_theme.Foreground.Y,_theme.Foreground.Z)";
                _reusableExpressionAnimation.SetReferenceParameter("my", propertySet);
                _reusableExpressionAnimation.SetReferenceParameter("_theme", _themeProperties);
                result.StartAnimation("Color", _reusableExpressionAnimation);
                StartProgressBoundAnimation(propertySet, "Opacity0", Opacity0ScalarAnimation_1_to_0(), _rootProgress);
                return result;
            }

            // Traversal order: 49
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path / ShapeGroup: Ellipse A
            // Ellipse Path.EllipseGeometry
            // TrimEnd
            ScalarKeyFrameAnimation TrimEndScalarAnimation_0_to_0p5()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(0, 9.99999975E-05F, _holdThenStepEasingFunction);
                result.InsertKeyFrame(0.5F, 0.5F, _cubicBezierEasingFunction_0);
                return result;
            }

            // Traversal order: 25
            // Layer (Shape): Radial
            // Transforms: Radial
            // Ellipse Path / ShapeGroup: Ellipse B
            // Ellipse Path.EllipseGeometry
            // TrimStart
            ScalarKeyFrameAnimation TrimStartScalarAnimation_0_to_0p5()
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(0, 0, StepThenHoldEasingFunction());
                result.InsertKeyFrame(0.5F, 0, HoldThenStepEasingFunction());
                result.InsertKeyFrame(1, 0.5F, CubicBezierEasingFunction_0());
                return result;
            }

            internal AnimatedVisual(
                Compositor compositor,
                CompositionPropertySet themeProperties
                )
            {
                _c = compositor;
                _themeProperties = themeProperties;
                _reusableExpressionAnimation = compositor.CreateExpressionAnimation();
                Root();
            }

            Visual IAnimatedVisual.RootVisual => _root;
            TimeSpan IAnimatedVisual.Duration => TimeSpan.FromTicks(c_durationTicks);
            Vector2 IAnimatedVisual.Size => new Vector2(100, 100);
            void IDisposable.Dispose() => _root?.Dispose();

            internal static bool IsRuntimeCompatible()
            {
                return Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7);
            }
        }
    }
}
