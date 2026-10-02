using MelonLoader;
using UnityEngine;
using MateriaLib;
using DifferentRopeMaterials;
using CustomDistributionAPI;

[assembly: MelonInfo(typeof(CGNiksCustomRopeVariants.Core), "CGNiksCustomRopeVariants", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace CGNiksCustomRopeVariants
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            MateriaLib.Main.SetupMaterial += SetupMaterial;
        }

        private static LibMaterial AddRope(string name, int hash, MaterialConfig materialConfig, Vector4 colorA, Vector4 color, bool addToDistribution, float baseValue = 1f, float noAttributeValue = 1f, AttributeCurveRange[] multipliers = null)
        {
            LibMaterial libMaterial = new LibMaterial(name, hash, LibMaterial.MaterialType.rope);

            LibMaterial.NewMaterials.Add(libMaterial);

            libMaterial.Configure(materialConfig);

            Material mateial = UnityEngine.Object.Instantiate(libMaterial.physicalMaterial.GetMaterial(PhysicalMaterialChannel.A));

            mateial.name = name;

            mateial.SetVector("_ColorA", colorA);
            mateial.SetVector("_Color", color);

            libMaterial.ReplaceAllMaterials(mateial);

            if (addToDistribution)
            {
                CustomDistributionAPI.Core.AddToDistribution(DifferentRopeMaterials.Core.ropeMaterialDistribution, libMaterial.physicalMaterial, baseValue, noAttributeValue, multipliers);
            }

            return libMaterial;
        }

        public static void SetupMaterial()
        {
            AddRope(
                "White Rope",
                35211,
                new MaterialConfig() { },
                new Vector4(0.7f, 0.7f, 0.7f, 1f),
                new Vector4(0.8f, 0.8f, 0.8f, 1f),
                true,
                0.35f,
                0.35f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 1f),
                            new Keyframe(1f, 0f)
                        }),
                        0f,
                        50f
                    )
                }
            );

            AddRope(
                "Light Gray Rope",
                35212,
                new MaterialConfig() { },
                new Vector4(0.53f, 0.53f, 0.53f, 1f),
                new Vector4(0.6f, 0.6f, 0.6f, 1f),
                true,
                0.4f,
                0.4f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        10f
                    )
                }
            );

            AddRope(
                "Dark Gray Rope",
                35213,
                new MaterialConfig() { },
                new Vector4(0.3f, 0.3f, 0.3f, 1f),
                new Vector4(0.35f, 0.35f, 0.35f, 1f),
                true,
                0.4f,
                0.4f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.5f),
                            new Keyframe(1f, 0f)
                        }),
                        0f,
                        100f
                    )
                }
            );

            AddRope(
                "Black Rope",
                35214,
                new MaterialConfig() { },
                new Vector4(0.15f, 0.15f, 0.15f, 1f),
                new Vector4(0.2f, 0.2f, 0.2f, 1f),
                true,
                0.35f,
                0.35f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.25f),
                            new Keyframe(1f, 1f)
                        }),
                        40f,
                        60f
                    )
                }
            );

            AddRope(
                "Light Brown Rope",
                35215,
                new MaterialConfig() { },
                new Vector4(0.47f * 1.4f, 0.3f * 1.4f, 0.11f * 1.4f, 1f),
                new Vector4(0.6f * 1.4f, 0.4f * 1.4f, 0.18f * 1.4f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.5f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        30f
                    )
                }
            );

            AddRope(
                "Dark Brown Rope",
                35216,
                new MaterialConfig() { },
                new Vector4(0.47f * 0.7f, 0.3f * 0.7f, 0.11f * 0.7f, 1f),
                new Vector4(0.6f * 0.7f, 0.4f * 0.7f, 0.18f * 0.7f, 1f),
                true,
                0.5f,
                0.5f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.5f),
                            new Keyframe(1f, 1f)
                        }),
                        30f,
                        60f
                    )
                }
            );
        }
    }
}