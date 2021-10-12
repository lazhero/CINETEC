package com.example.cinetec.entities;

public class Movie {
    String Original_name;
    String Name;
    String Image;

    public String getOriginal_name() {
        return Original_name;
    }

    public void setOriginal_name(String original_name) {
        Original_name = original_name;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getImage() {
        return Image;
    }

    public void setImage(String image) {
        Image = image;
    }

    public Movie(String original_name, String name, String image) {
        Original_name = original_name;
        Name = name;
        Image = image;
    }
}
