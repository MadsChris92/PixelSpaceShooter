using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AcceleroTest : MonoBehaviour {

    public Text testetes;
    public LineRenderer lineRider;

    public Text marginText;
    public Slider marginSlider;

    float distance = 0;
    float lastDistance = 0;
    Vector3 lastPlace = new Vector3(0,0,0);
    Vector3 filter = new Vector3(0, 0, 0);

    Vector3[] places = new Vector3[50];
    int placesRecorded = 0;

    IEnumerator Start() {
        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
    }

    float calculateDistance(Vector3 point1, Vector3 point2) {
        float degreeToRad = Mathf.PI/180.0f;
        float dlong = (point2.x - point1.x) * degreeToRad;
        float dlat = (point2.y - point1.y) * degreeToRad;
        float a = Mathf.Pow(dlat/2.0f, 2) + Mathf.Cos(point1.y * degreeToRad) * Mathf.Cos(point2.y * degreeToRad) * Mathf.Pow(dlong/2.0f, 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        return 6367 * c * 1000;
    }

    // Update is called once per frame
    void Update() {
        Vector3 affector = Input.acceleration;
        testetes.text = "Magnitude: " + affector.magnitude + 
            "\n\nLocation Status: " + Input.location.status;
        marginText.text = "Margin: " + Mathf.Floor( marginSlider.value ) + "("+ Mathf.Floor( lastDistance ) +")";
        if (Input.location.isEnabledByUser || true) {

            Vector3 newPlace;
            if (Input.location.status == LocationServiceStatus.Running) {
                newPlace = new Vector3(Input.location.lastData.longitude, Input.location.lastData.latitude, Input.location.lastData.altitude);
            } else {
                newPlace = Input.mousePosition * 0.0001f ;
            }


            DateTime when = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(Input.location.lastData.timestamp).ToLocalTime();
            testetes.text += "\nLocation: " + newPlace + " at " + when.ToString() +
                "\nDistance: " + distance + " meters";

            if (placesRecorded == 0) {
                if (!newPlace.Equals(new Vector3(0, 0, 0))) {
                    lastPlace = newPlace;
                    places[placesRecorded] = lastPlace;
                    placesRecorded++;
                    filter = lastPlace;
                }
            } else {
                if (newPlace.Equals(new Vector3(0, 0, 0))) newPlace = lastPlace;
                if (!newPlace.Equals(lastPlace)) {
                    lastDistance = calculateDistance(newPlace, filter);
                    filter = Vector3.Lerp(filter, newPlace, 0.5f);
                    lastPlace = newPlace;
                    if (lastDistance < marginSlider.value) {
                        if (placesRecorded < places.Length) {
                            places[placesRecorded] = newPlace;
                            placesRecorded++;
                        } else {
                            for (int i = 0; i < places.Length - 1; i++) {
                                places[i] = places[i + 1];
                            }
                            places[places.Length - 1] = newPlace;
                        }
                        distance += calculateDistance(places[placesRecorded-1], places[placesRecorded-2]);
                        lineRider.SetVertexCount(placesRecorded);
                        Vector3 offset;
                        offset = places[0];
                        float largest = 0.00001f;
                        for (int i = 0; i < placesRecorded; i++) {
                            largest = Mathf.Max(largest, (places[i] - offset).magnitude);
                        }
                        float scale = 5 / largest;
                        for (int i = 0; i < placesRecorded; i++) {
                            lineRider.SetPosition(i, (places[i] - offset) * scale);
                        }
                    }
                }
            }
            
            testetes.text += "\nFilter: " + lastPlace*1000 + " <--> " + filter*1000;

            testetes.text += "\nPlaces: {";
            for (int i = placesRecorded-1; i >= Mathf.Max(placesRecorded-10, 0); i--) {
                testetes.text += "\n  " + places[i]*1000;
            }
            testetes.text += "\n}";
        } else {
            testetes.text += "\n\nLocation Disabled";
            affector.Scale(new Vector3(100, 100, -100));
            GetComponent<Rigidbody>().AddForce(affector);
        }
            
	}
}
