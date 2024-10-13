
    using UnityEngine;

    //Builder
    public class PipeBuilder
    {        
        //product
        private GameObject instancedPipe;

        public PipeBuilder(GameObject baseObject) : this(baseObject, Vector3.zero, Quaternion.identity) {}
        public PipeBuilder(GameObject baseObject, Vector3 position) : this(baseObject, position, Quaternion.identity) {}

        public PipeBuilder(GameObject baseObject, Vector3 position, Quaternion rotation)
        {
            instancedPipe = Object.Instantiate(baseObject,position, rotation);
            instancedPipe.SetActive(false);
        }

        public PipeBuilder SetPosition(Vector3 position)
        {
            instancedPipe.transform.position = position;

            return this;
        }

        /// Add an oscillator.
        /// Values over 0 substitute default values on the script.
        /// Default Oscillator values: speed=2,amplitude=5
        public PipeBuilder AddOscillator(float oscillationSpeed, float amplitude)
        {
            Object.Destroy(instancedPipe.GetComponent<Oscillator>());
            Oscillator o = instancedPipe.AddComponent<Oscillator>();
            if (oscillationSpeed > 0) o.speed = oscillationSpeed;
            if (amplitude > 0 ) o.amplitude = amplitude;

            return this;
        }

        //add coinPrefab al AddPortals
        public PipeBuilder AddPortals(GameObject prefab)
        {
            PipePortalManager existing = instancedPipe.GetComponent<PipePortalManager>();
            if (existing != null)
                Object.Destroy(instancedPipe.GetComponent<PipePortalManager>().gameObject);
            Object.Instantiate(prefab, instancedPipe.transform);
            
            return this;
        }
        
        public GameObject Build()
        {
            instancedPipe.SetActive(true);
            return instancedPipe;
        }
    }