package com.example.cinetec.customviews;

import android.content.Context;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;

import androidx.annotation.Nullable;

import com.example.cinetec.R;
import com.example.cinetec.entities.Movie;
import com.google.android.material.button.MaterialButton;

public class MovieView extends LinearLayout {
    private ImageView cover;
    private MaterialButton button;
    private Movie movie;
    public MovieView(Context context) {
        super(context);
        LayoutInflater.from(context).inflate(R.layout.view_movie,this,true);
    }

    public MovieView(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
    }

    public MovieView(Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
    }

    public MovieView(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        View view=LayoutInflater.from(context).inflate(R.layout.view_movie,this);
        cover=(ImageView) findViewById(R.id.cover);
        button=(MaterialButton)findViewById(R.id.branch_logo);

    }
    public void setMovie(Movie movie){
        this.movie=movie;

    }
}
