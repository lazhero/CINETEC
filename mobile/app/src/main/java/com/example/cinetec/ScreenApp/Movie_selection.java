package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.res.Resources;
import android.os.Bundle;
import android.util.TypedValue;
import android.widget.LinearLayout;

import com.example.cinetec.R;
import com.example.cinetec.customviews.Matrix_layout;
import com.example.cinetec.customviews.MovieView;

public class Movie_selection extends AppCompatActivity {

    private int width;
    Matrix_layout layout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_movie_selection);
        width=(int) TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP,
                getResources().getDimension(R.dimen.movie_size),
                getResources().getDisplayMetrics()
        );
        layout=findViewById(R.id.movies_matrix_layout);
        add_movies_example();
    }

    public void add_movies_example(){

        LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.WRAP_CONTENT,
                LinearLayout.LayoutParams.WRAP_CONTENT
        );
        params.setMargins(dp_px(2), 0, dp_px(2), dp_px(2));

        for(int i=0;i<15;i++){
            MovieView movie=new MovieView(this);
            movie.set_cover_size(width);
            movie.setLayoutParams(params);
            layout.add_view(movie);
        }

    }
    private int dp_px(int measure){
        Resources r = this.getResources();
        int px = (int) TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP,
                15,
                r.getDisplayMetrics()
        );
        return px;
    }


}